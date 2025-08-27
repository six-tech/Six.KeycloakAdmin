#!/usr/bin/env dotnet
#:package CliWrap@3.6.6
#:package Spectre.Console@0.49.1

using System;
using System.IO;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using Spectre.Console;

// Set working directory to solution root
var currentDir = Directory.GetCurrentDirectory();
if (currentDir.EndsWith("build"))
{
    Directory.SetCurrentDirectory("..");
}

// Interactive test runner menu
AnsiConsole.Write(
    new FigletText("Six Runner")
        .LeftJustified()
        .Color(Color.Cyan1));

AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("[grey]Powered by .NET 10 File-Based Apps[/]");
AnsiConsole.WriteLine();

var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[green]What would you like to do?[/]")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
        .AddChoices(new[] {
            "🧪 Run All Tests",
            "📊 Run Tests with Coverage",
            "📈 Generate Coverage Report",
            "🔍 Run Specific Test Project",
            "🧹 Clean Test Results",
            "📦 Pack NuGet Packages",
            "❌ Exit"
        }));

switch (choice)
{
    case "🧪 Run All Tests":
        await RunCommand("build/tests-run.cs");
        break;
        
    case "📊 Run Tests with Coverage":
        await RunCommand("build/tests-coverage.cs");
        break;
        
    case "📈 Generate Coverage Report":
        await RunCommand("build/tests-report.cs");
        break;
        
    case "🔍 Run Specific Test Project":
        await RunSpecificProject();
        break;
        
    case "🧹 Clean Test Results":
        await CleanTestResults();
        break;
        
    case "📦 Pack NuGet Packages":
        await RunCommand("build/nuget-pack.cs");
        break;
        
    case "❌ Exit":
        AnsiConsole.MarkupLine("[grey]Goodbye![/]");
        break;
}

async Task RunCommand(string scriptFile)
{
    if (!File.Exists(scriptFile))
    {
        AnsiConsole.MarkupLine($"[red]Script file '{scriptFile}' not found![/]");
        return;
    }

    AnsiConsole.MarkupLine($"[cyan]Running {scriptFile}...[/]");
    AnsiConsole.WriteLine();

    try
    {
        var result = await Cli.Wrap("dotnet")
            .WithArguments($"run {scriptFile}")
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line => AnsiConsole.WriteLine(line)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line => AnsiConsole.MarkupLine($"[red]{line}[/]")))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();

        AnsiConsole.WriteLine();
        if (result.ExitCode == 0)
        {
            AnsiConsole.MarkupLine($"[green]✓ {scriptFile} completed successfully[/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]✗ {scriptFile} failed with exit code {result.ExitCode}[/]");
        }
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]Error executing {scriptFile}: {ex.Message}[/]");
    }
}

async Task RunSpecificProject()
{
    var testProjects = Directory.GetFiles(".", "*.Tests*.csproj", SearchOption.AllDirectories)
        .Where(p => !p.Contains("bin") && !p.Contains("obj"))
        .Select(p => Path.GetFileNameWithoutExtension(p))
        .ToArray();

    if (testProjects.Length == 0)
    {
        AnsiConsole.MarkupLine("[red]No test projects found![/]");
        return;
    }

    var project = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[green]Select a test project to run:[/]")
            .PageSize(10)
            .AddChoices(testProjects));

    try
    {
        var projectFile = Directory.GetFiles(".", $"{project}.csproj", SearchOption.AllDirectories)
            .FirstOrDefault(p => !p.Contains("bin") && !p.Contains("obj"));

        if (projectFile == null)
        {
            AnsiConsole.MarkupLine($"[red]Project file not found![/]");
            return;
        }

        var withCoverage = AnsiConsole.Confirm("Run with code coverage?");
        
        var arguments = withCoverage
            ? $"test \"{projectFile}\" --collect:\"XPlat Code Coverage\" --results-directory TestResults"
            : $"test \"{projectFile}\"";

        AnsiConsole.MarkupLine($"[cyan]Running tests for {project}...[/]");
        AnsiConsole.WriteLine();

        var result = await Cli.Wrap("dotnet")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line => AnsiConsole.WriteLine(line)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line => AnsiConsole.MarkupLine($"[red]{line}[/]")))
            .ExecuteAsync();

        AnsiConsole.WriteLine();
        if (result.ExitCode == 0)
        {
            AnsiConsole.MarkupLine($"[green]✓ Tests passed for {project}[/]");
            
            if (withCoverage)
            {
                AnsiConsole.MarkupLine("[yellow]Coverage data saved to TestResults directory[/]");
            }
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]✗ Tests failed for {project}[/]");
        }
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]Error: {ex.Message}[/]");
    }
}

async Task CleanTestResults()
{
    await AnsiConsole.Status()
        .Spinner(Spinner.Known.Dots)
        .StartAsync("Cleaning test results...", async ctx =>
        {
            try
            {
                var testResultsDirs = Directory.GetDirectories(".", "TestResults", SearchOption.AllDirectories)
                    .Where(d => !d.Contains("bin") && !d.Contains("obj"))
                    .ToArray();

                var coverageReportsDir = "coverage-reports";
                
                var dirsToClean = testResultsDirs.ToList();
                if (Directory.Exists(coverageReportsDir))
                {
                    dirsToClean.Add(coverageReportsDir);
                }

                if (dirsToClean.Count == 0)
                {
                    AnsiConsole.MarkupLine("[yellow]No test results to clean[/]");
                    return;
                }

                foreach (var dir in dirsToClean)
                {
                    ctx.Status($"Deleting {dir}...");
                    Directory.Delete(dir, true);
                    AnsiConsole.MarkupLine($"[green]✓ Deleted {dir}[/]");
                }

                AnsiConsole.MarkupLine($"[green]Cleaned {dirsToClean.Count} directories[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error: {ex.Message}[/]");
            }
            
            await Task.CompletedTask; // Ensure async compilation
        });
}

// Ask if user wants to run another task
if (choice != "❌ Exit")
{
    AnsiConsole.WriteLine();
    if (AnsiConsole.Confirm("Would you like to run another task?"))
    {
        // Re-run the script
        await Cli.Wrap("dotnet")
            .WithArguments("run build/runner.cs")
            .ExecuteAsync();
    }
}
