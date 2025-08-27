namespace Six.KeycloakAdmin.Tests.AppHost;

/// <summary>
/// Provides default configuration values for Keycloak integration tests.
/// </summary>
public static class KeycloakAdminDefaults
{
  public const string AspireResourceName = "test-keycloak";
  public const int Port = 50648;
  public const string AdminUsername = "admin";
  public const string AdminPassword = "admin";
  
  public static string TestRealmFileName => FindRealmImportFilePath();
  
  
  /// <summary>
  /// Searches for the realm import file by first looking in the current directory and parent directories,
  /// then searching recursively in the 'tests' directory if the solution root is reached.
  /// </summary>
  /// <returns>The absolute path to the insurance-realm-export.json file.</returns>
  /// <exception cref="FileNotFoundException">Thrown when the file is not found in any directory.</exception>
  public static string FindRealmImportFilePath()
  {
    const string fileName = "insurance-realm-export.json";
    var currentDirectory = Directory.GetCurrentDirectory();
    string? solutionRootDirectory = null;
    
    // First pass: search upward while looking for solution root
    while (currentDirectory is not null)
    {
      // Check if current directory contains the file
      var filePath = Path.Combine(currentDirectory, fileName);
      if (File.Exists(filePath))
      {
        return filePath;
      }
      
      // Check if this is the solution root directory
      if (IsSolutionRootDirectory(currentDirectory))
      {
        solutionRootDirectory = currentDirectory;
        break;
      }
      
      currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
    }
    
    // If we found the solution root but not the file, search in the tests directory
    if (solutionRootDirectory is not null)
    {
      var testsDirectory = Path.Combine(solutionRootDirectory, "tests");
      if (Directory.Exists(testsDirectory))
      {
        var foundFilePath = SearchFileRecursively(testsDirectory, fileName);
        if (foundFilePath is not null)
        {
          return foundFilePath;
        }
      }
    }
    
    throw new FileNotFoundException($"The file '{fileName}' was not found in any parent directory or in the tests directory.");
  }
  
  /// <summary>
  /// Determines if the specified directory is a solution root directory by checking for .sln or .slnx files.
  /// </summary>
  /// <param name="directoryPath">The directory path to check.</param>
  /// <returns>True if the directory contains solution files, false otherwise.</returns>
  static bool IsSolutionRootDirectory(string directoryPath)
  {
    var solutionFiles = Directory.GetFiles(directoryPath, "*.sln", SearchOption.TopDirectoryOnly);
    var solutionXFiles = Directory.GetFiles(directoryPath, "*.slnx", SearchOption.TopDirectoryOnly);
    
    return solutionFiles.Length > 0 || solutionXFiles.Length > 0;
  }
  
  
  /// <summary>
  /// Recursively searches for a file in the specified directory and all its subdirectories.
  /// </summary>
  /// <param name="directoryPath">The directory path to search in.</param>
  /// <param name="fileName">The name of the file to search for.</param>
  /// <returns>The absolute path to the file if found, null otherwise.</returns>
  static string? SearchFileRecursively(string directoryPath, string fileName)
  {
    try
    {
      // Search in current directory
      var filePath = Path.Combine(directoryPath, fileName);
      if (File.Exists(filePath))
      {
        return filePath;
      }
      
      // Search in subdirectories
      var subdirectories = Directory.GetDirectories(directoryPath);
      foreach (var subdirectory in subdirectories)
      {
        var foundFilePath = SearchFileRecursively(subdirectory, fileName);
        if (foundFilePath is not null)
        {
          return foundFilePath;
        }
      }
    }
    catch (UnauthorizedAccessException)
    {
      // Skip directories we don't have access to
    }
    catch (DirectoryNotFoundException)
    {
      // Skip directories that no longer exist
    }
    
    return null;
  }
}