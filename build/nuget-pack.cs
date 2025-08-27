#!/usr/bin/env dotnet
#:package CliWrap@3.6.6
#:package Spectre.Console@0.49.1

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliWrap;
using Spectre.Console;

// Set working directory to solution root if we're in the build directory
if (Directory.GetCurrentDirectory().EndsWith("build"))
{
    Directory.SetCurrentDirectory("..");
}

// Configuration
// --------------------------------------------------------------------------------

// If needed, add directories to search for projects
var searchDirectories = new List<string>
{
    "libs"  // Default to libs directory
};

// If needed, add projects to ignore by full project names
var ignoredProjects = new List<string>
{
    // Add project names to ignore here
    // Example: "Six.Example.TestProject"
};

var buildConfig = args.Contains("--debug") ? "Debug" : "Release";
var publishMode = GetPublishMode(args);

// Environment variables
var devLocalFeed = Environment.GetEnvironmentVariable("DEV_LOCAL_NUGET_FEED_URL");
var personalFeed = Environment.GetEnvironmentVariable("PRIVATE_NUGET_FEED_URL");
var personalApiKey = Environment.GetEnvironmentVariable("PRIVATE_NUGET_FEED_PAT");
var publicNugetApiKey = Environment.GetEnvironmentVariable("PUBLIC_NUGET_FEED_PAT");
var publicNugetFeed = "https://api.nuget.org/v3/index.json";


AnsiConsole.Write(new FigletText("Six NuGet Packager").Color(Color.Green));
AnsiConsole.WriteLine();

await AnsiConsole.Status()
    .Spinner(Spinner.Known.Dots)
    .StartAsync("Processing NuGet packaging...", async ctx =>
    {
        try
        {
            // Validate environment based on publish mode
            ValidateEnvironment(publishMode, devLocalFeed, personalFeed, personalApiKey, publicNugetApiKey);

            // Discover projects
            ctx.Status("Discovering projects...");
            var projects = DiscoverProjects(searchDirectories, ignoredProjects);
            
            if (projects.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No projects found to package![/]");
                return;
            }

            AnsiConsole.MarkupLine($"[green]Found {projects.Count} project(s) to package[/]");
            foreach (var project in projects)
            {
                AnsiConsole.MarkupLine($"[dim]  • {Path.GetFileNameWithoutExtension(project)}[/]");
            }
            AnsiConsole.WriteLine();

            // Build and pack projects in parallel
            ctx.Status("Building and packing projects...");
            var outputDir = GetOutputDirectory(publishMode, devLocalFeed);
            var packResults = await BuildAndPackProjectsAsync(projects, buildConfig, outputDir);

            // Report packed projects
            ReportPackedProjects(packResults);

            // Publish if not local-only
            List<PublishResult> publishResults = new();
            if (publishMode == PublishMode.LocalOnly)
            {
                ctx.Status("Copying packages to local feed...");
                publishResults = await CopyPackagesToLocalFeedAsync(packResults, devLocalFeed!, outputDir);
                ReportPublishedProjects(publishResults);
            }
            else
            {
                ctx.Status("Publishing packages...");
                publishResults = await PublishPackagesAsync(packResults, publishMode, personalFeed, personalApiKey, publicNugetFeed, publicNugetApiKey, outputDir);
                ReportPublishedProjects(publishResults);
            }

            // Final summary
            ctx.Status("Generating summary...");
            DisplaySummary(packResults, publishResults, publishMode, outputDir, devLocalFeed, personalFeed);
            
            // Cleanup packages directory after successful publishing
            if (publishResults.Any(r => r.Success) && Directory.Exists(outputDir))
            {
                ctx.Status("Cleaning up...");
                try
                {
                    Directory.Delete(outputDir, true);
                    AnsiConsole.MarkupLine("[dim]Cleaned up temporary packages directory[/]");
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[yellow]Warning: Could not clean up packages directory: {ex.Message}[/]");
                }
            }
            
            ctx.Status("Completed!");
            await Task.Delay(100); // Brief pause to show completion
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error: {ex.Message}[/]");
            Environment.Exit(1);
        }
    });

// Clear any remaining status and show completion message
AnsiConsole.WriteLine();
AnsiConsole.Write(new Rule("[green]✅ NuGet Packaging Completed![/]").LeftJustified());



// Helper Methods
// -----------------------------------------------------------------------------------------------------
PublishMode GetPublishMode(string[] args)
{
    if (args.Contains("--local")) return PublishMode.LocalOnly;
    if (args.Contains("--private")) return PublishMode.Private;
    if (args.Contains("--public")) return PublishMode.Public;
    return PublishMode.LocalOnly; // Default to local feed only
}

void ValidateEnvironment(PublishMode mode, string? devLocal, string? privateFeed, string? privateApiKey, string? publicApiKey)
{
    switch (mode)
    {
        case PublishMode.LocalOnly:
            if (string.IsNullOrEmpty(devLocal))
                throw new InvalidOperationException("DEV_LOCAL_NUGET_FEED_URL environment variable is required for local publishing");
            break;
        case PublishMode.Private:
            if (string.IsNullOrEmpty(privateFeed))
                throw new InvalidOperationException("PRIVATE_NUGET_FEED_URL environment variable is required for private feed publishing");
            if (string.IsNullOrEmpty(privateApiKey))
                throw new InvalidOperationException("PRIVATE_NUGET_FEED_PAT environment variable is required for private feed publishing");
            break;
        case PublishMode.Public:
            if (string.IsNullOrEmpty(publicApiKey))
                throw new InvalidOperationException("PUBLIC_NUGET_API_KEY template variable needs to be replaced with actual API key");
            break;
    }
}

List<string> DiscoverProjects(List<string> searchDirs, List<string> ignored)
{
    var projects = new List<string>();
    
    foreach (var dir in searchDirs)
    {
        if (!Directory.Exists(dir))
        {
            AnsiConsole.MarkupLine($"[yellow]Warning: Directory '{dir}' does not exist, skipping...[/]");
            continue;
        }

        var foundProjects = Directory.GetFiles(dir, "*.csproj", SearchOption.AllDirectories)
            .Where(p => !ignored.Any(ignore => Path.GetFileNameWithoutExtension(p).Equals(ignore, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        projects.AddRange(foundProjects);
    }

    return projects.OrderBy(p => Path.GetFileNameWithoutExtension(p)).ToList();
}

string GetOutputDirectory(PublishMode mode, string? devLocal)
{
    // Always use packages directory for initial packaging
    // Local feed copying happens separately
    return Path.Combine(Directory.GetCurrentDirectory(), "packages");
}

async Task<List<PackResult>> BuildAndPackProjectsAsync(List<string> projects, string config, string outputDir)
{
    // Ensure output directory exists
    Directory.CreateDirectory(outputDir);

    var results = new List<PackResult>();
    
    // Build and pack sequentially to avoid file lock issues with dependencies
    foreach (var project in projects)
    {
        var projectName = Path.GetFileNameWithoutExtension(project);
        
        try
        {
            // Build with output capture
            var buildOutput = new StringBuilder();
            var buildError = new StringBuilder();
            
            var buildResult = await Cli.Wrap("dotnet")
                .WithArguments($"build \"{project}\" -c {config} --verbosity normal")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(buildOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(buildError))
                .ExecuteAsync();

            if (buildResult.ExitCode != 0)
            {
                var errorMessage = GetErrorMessage(buildError.ToString(), buildOutput.ToString(), "Build failed");
                results.Add(new PackResult(projectName, false, errorMessage));
                continue;
            }

            // Pack - always create symbols for proper remote publishing
            var packOutput = new StringBuilder();
            var packError = new StringBuilder();
            
            var packResult = await Cli.Wrap("dotnet")
                .WithArguments($"pack \"{project}\" -c {config} -o \"{outputDir}\" --no-build --include-symbols -p:SymbolPackageFormat=snupkg --verbosity normal")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(packOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(packError))
                .ExecuteAsync();

            if (packResult.ExitCode != 0)
            {
                var errorMessage = GetErrorMessage(packError.ToString(), packOutput.ToString(), "Pack failed");
                results.Add(new PackResult(projectName, false, errorMessage));
                continue;
            }

            results.Add(new PackResult(projectName, true, "Success"));
        }
        catch (Exception ex)
        {
            results.Add(new PackResult(projectName, false, ex.Message));
        }
    }

    return results;
}

Task<List<PublishResult>> CopyPackagesToLocalFeedAsync(List<PackResult> packResults, string localFeedPath, string outputDir)
{
    var successfulPacks = packResults.Where(r => r.Success).ToList();
    
    // Ensure local feed directory exists
    Directory.CreateDirectory(localFeedPath);
    
    var results = new List<PublishResult>();
    
    foreach (var pack in successfulPacks)
    {
        try
        {
            // Find all package files for this project (.nupkg and .snupkg)
            var packageFiles = Directory.GetFiles(outputDir, $"{pack.ProjectName}*.*nupkg")
                .OrderByDescending(f => File.GetLastWriteTime(f))
                .ToArray();

            if (packageFiles.Length == 0)
            {
                results.Add(new PublishResult(pack.ProjectName, false, "No package files found"));
                continue;
            }

            // Copy all package files to local feed
            foreach (var packageFile in packageFiles)
            {
                var fileName = Path.GetFileName(packageFile);
                var destPath = Path.Combine(localFeedPath, fileName);
                File.Copy(packageFile, destPath, true);
            }

            results.Add(new PublishResult(pack.ProjectName, true, $"Copied to {localFeedPath}"));
        }
        catch (Exception ex)
        {
            results.Add(new PublishResult(pack.ProjectName, false, ex.Message));
        }
    }
    
    return Task.FromResult(results);
}

async Task<List<PublishResult>> PublishPackagesAsync(
  List<PackResult> packResults, 
  PublishMode mode, 
  string? personalFeed, 
  string? personalApiKey, 
  string publicUrl, 
  string publicApiKey,
  string outputDir)
{
    var successfulPacks = packResults.Where(r => r.Success).ToList();
    
    var (feedUrl, apiKey) = mode switch
    {
        PublishMode.Private => (personalFeed!, personalApiKey!),
        PublishMode.Public => (publicUrl, publicApiKey),
        _ => throw new ArgumentException("Invalid publish mode for publishing")
    };

    var tasks = successfulPacks.Select(async pack =>
    {
        try
        {
            // Find the latest .nupkg file for this project (like the PowerShell script)
            var packageFiles = Directory.GetFiles(outputDir, $"{pack.ProjectName}*.nupkg")
                .Where(f => !f.EndsWith(".snupkg"))
                .OrderByDescending(f => File.GetLastWriteTime(f))
                .ToArray();

            if (packageFiles.Length == 0)
            {
                return new PublishResult(pack.ProjectName, false, "No package file found");
            }

            var latestNugetPackage = packageFiles[0];
            
            // Find corresponding .snupkg file (like the PowerShell script)
            var packageBaseName = Path.GetFileNameWithoutExtension(latestNugetPackage);
            var snupkgFiles = Directory.GetFiles(outputDir, $"{pack.ProjectName}*.snupkg")
                .Where(f => Path.GetFileNameWithoutExtension(f) == packageBaseName)
                .OrderByDescending(f => File.GetLastWriteTime(f))
                .ToArray();

            // Push main package
            var pushOutput = new StringBuilder();
            var pushError = new StringBuilder();
            
            var pushResult = await Cli.Wrap("dotnet")
                .WithArguments($"nuget push \"{latestNugetPackage}\" --skip-duplicate --api-key \"{apiKey}\" --source \"{feedUrl}\"")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(pushOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(pushError))
                .ExecuteAsync();

            if (pushResult.ExitCode != 0)
            {
                var errorMessage = GetErrorMessage(pushError.ToString(), pushOutput.ToString(), "Push failed");
                return new PublishResult(pack.ProjectName, false, errorMessage);
            }

            // Push symbols if exists (matching the PowerShell script logic)
            if (snupkgFiles.Length > 0)
            {
                var latestSnupkgFile = snupkgFiles[0];
                var symbolPushOutput = new StringBuilder();
                var symbolPushError = new StringBuilder();
                
                var symbolPushResult = await Cli.Wrap("dotnet")
                    .WithArguments($"nuget push \"{latestSnupkgFile}\" --skip-duplicate --api-key \"{apiKey}\" --source \"{feedUrl}\"")
                    .WithValidation(CommandResultValidation.None)
                    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(symbolPushOutput))
                    .WithStandardErrorPipe(PipeTarget.ToStringBuilder(symbolPushError))
                    .ExecuteAsync();

                // Symbol push failure is not critical
                if (symbolPushResult.ExitCode != 0)
                {
                    return new PublishResult(pack.ProjectName, true, "Package published (symbols failed)");
                }
                
                return new PublishResult(pack.ProjectName, true, "Published with symbols");
            }

            return new PublishResult(pack.ProjectName, true, "Published successfully");
        }
        catch (Exception ex)
        {
            return new PublishResult(pack.ProjectName, false, ex.Message);
        }
    });

    return (await Task.WhenAll(tasks)).ToList();
}

void ReportPackedProjects(List<PackResult> results)
{
    AnsiConsole.WriteLine();
    AnsiConsole.Write(new Rule("[green]📦 Packaging Results[/]").LeftJustified());
    
    var table = new Table()
        .Border(TableBorder.Rounded)
        .AddColumn("Project")
        .AddColumn("Status")
        .AddColumn(new TableColumn("Details").Width(60));

    foreach (var result in results.OrderBy(r => r.ProjectName))
    {
        var status = result.Success ? "[green]✓ Success[/]" : "[red]✗ Failed[/]";
        var details = result.Success ? "[dim]Packaged successfully[/]" : $"[red]{TruncateMessage(result.Message, 55).EscapeMarkup()}[/]";
        
        table.AddRow(result.ProjectName, status, details);
        
        // If there's a failure with a long message, show it separately
        if (!result.Success && result.Message.Length > 55)
        {
            AnsiConsole.MarkupLine($"[red]  {result.ProjectName} Error Details:[/] {result.Message.EscapeMarkup()}");
        }
    }

    AnsiConsole.Write(table);
    
    var successful = results.Count(r => r.Success);
    var failed = results.Count(r => !r.Success);
    
    AnsiConsole.MarkupLine($"\n[green]✓ {successful} project(s) packaged successfully[/]");
    if (failed > 0)
    {
        AnsiConsole.MarkupLine($"[red]✗ {failed} project(s) failed to package[/]");
    }
}

void ReportPublishedProjects(List<PublishResult> results)
{
    if (results.Count == 0) return;

    AnsiConsole.WriteLine();
    AnsiConsole.Write(new Rule("[blue]🚀 Publishing Results[/]").LeftJustified());
    
    var table = new Table()
        .Border(TableBorder.Rounded)
        .AddColumn("Project")
        .AddColumn("Status")
        .AddColumn(new TableColumn("Details").Width(60));

    foreach (var result in results.OrderBy(r => r.ProjectName))
    {
        var status = result.Success ? "[green]✓ Published[/]" : "[red]✗ Failed[/]";
        var details = result.Success ? "[dim]Published successfully[/]" : $"[red]{TruncateMessage(result.Message, 55).EscapeMarkup()}[/]";
        
        table.AddRow(result.ProjectName, status, details);
        
        // If there's a failure with a long message, show it separately
        if (!result.Success && result.Message.Length > 55)
        {
            AnsiConsole.MarkupLine($"[red]  {result.ProjectName} Publish Error Details:[/] {result.Message.EscapeMarkup()}");
        }
    }

    AnsiConsole.Write(table);
    
    var successful = results.Count(r => r.Success);
    var failed = results.Count(r => !r.Success);
    
    AnsiConsole.MarkupLine($"\n[green]✓ {successful} project(s) published successfully[/]");
    if (failed > 0)
    {
        AnsiConsole.MarkupLine($"[red]✗ {failed} project(s) failed to publish[/]");
    }
}

void DisplaySummary(List<PackResult> packResults, List<PublishResult> publishResults, PublishMode mode, string outputDir, string? devLocalFeed = null, string? personalFeed = null)
{
    AnsiConsole.WriteLine();
    AnsiConsole.Write(new Rule("[yellow]📋 Summary[/]").LeftJustified());
    
    var publishedTo = mode switch
    {
        PublishMode.LocalOnly => devLocalFeed,
        PublishMode.Private => personalFeed,
        PublishMode.Public => "NuGet.org",
        _ => "Unknown"
    };
    
    var panel = new Panel(
        $"""
        [green]Build Configuration:[/] {buildConfig}
        [green]Publish Mode:[/] {mode}
        [green]Output Directory:[/] {outputDir}
        [green]Packed Projects:[/] {packResults.Count(r => r.Success)}/{packResults.Count}
        {(publishResults.Count > 0 ? $"[green]Published Projects:[/] {publishResults.Count(r => r.Success)}/{publishResults.Count}" : "")}
        {(publishResults.Count > 0 && !string.IsNullOrEmpty(publishedTo) ? $"[green]Published To:[/] {publishedTo}" : "")}
        """)
        .Border(BoxBorder.Rounded)
        .BorderColor(Color.Green)
        .Header("[green]NuGet Packaging Summary[/]");
    
    AnsiConsole.Write(panel);
    
    AnsiConsole.WriteLine();
    AnsiConsole.Write(new Text("Usage: dotnet run build/nuget-pack.cs [--debug] [--local|--private|--public] (default: --local)", new Style(Color.Grey)));
    AnsiConsole.WriteLine();
}

string GetErrorMessage(string stderr, string stdout, string defaultMessage)
{
    // Combine stderr and stdout
    var allOutput = $"{stderr}\n{stdout}".Trim();
    
    if (string.IsNullOrWhiteSpace(allOutput))
        return defaultMessage;
    
    // Look for error lines
    var lines = allOutput.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    var errorLines = lines.Where(line => 
        line.Contains("error", StringComparison.OrdinalIgnoreCase) ||
        line.Contains("failed", StringComparison.OrdinalIgnoreCase) ||
        line.Contains("exception", StringComparison.OrdinalIgnoreCase))
        .Take(3) // Limit to first 3 error lines
        .ToArray();
    
    if (errorLines.Length > 0)
    {
        // Clean up the error messages
        var cleanErrors = errorLines.Select(line => 
            line.Trim()
                .Replace("error:", "", StringComparison.OrdinalIgnoreCase)
                .Replace("Error:", "", StringComparison.OrdinalIgnoreCase)
                .Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
        
        if (cleanErrors.Length > 0)
        {
            return string.Join(" | ", cleanErrors);
        }
    }
    
    // If no specific errors found, return first few lines of output
    var firstLines = lines.Take(2).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
    return firstLines.Length > 0 ? string.Join(" | ", firstLines) : defaultMessage;
}

string TruncateMessage(string message, int maxLength)
{
    if (string.IsNullOrEmpty(message) || message.Length <= maxLength)
        return message;
    
    return message.Substring(0, maxLength - 3) + "...";
}

// Data Models
public record PackResult(string ProjectName, bool Success, string Message);
public record PublishResult(string ProjectName, bool Success, string Message);

public enum PublishMode
{
    LocalOnly,
    Private,
    Public
}
