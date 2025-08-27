# Code Coverage for Keycloak Admin Integration Tests

This project is configured with comprehensive code coverage collection using Coverlet collector. The coverage reports provide detailed insights into which parts of the code are tested and which areas might need additional test coverage.

## Coverage Configuration

### Project File Settings
The project file (`Six.KeycloakAdmin.Tests.Integration.csproj`) includes comprehensive Coverlet configuration:

- **CollectCoverage**: Enabled by default
- **Output Formats**: Cobertura XML, HTML, and JSON
- **Output Directory**: `TestResults/` folder
- **Exclusions**: Generated files, test assemblies, and build artifacts
- **Source Link**: Enabled for better debugging support

### Run Settings File
The `coverlet.runsettings` file provides additional configuration for the test runner:

- **Data Collector**: XPlat Code Coverage
- **Include Directories**: Focuses on the main library source code
- **Exclude Directories**: Build artifacts and test code

## Running Tests with Coverage

### Option 1: PowerShell Script (Recommended)
```powershell
# Run the PowerShell script
.\run-tests-with-coverage.ps1
```

### Option 2: Windows Batch File
```cmd
# Run the batch file
run-tests-with-coverage.bat
```

### Option 3: Manual Command
```bash
# Run tests with coverage manually
dotnet test --settings coverlet.runsettings --collect:"XPlat Code Coverage" --logger "console;verbosity=normal" --results-directory TestResults
```

### Option 4: Using Project Properties
```bash
# Run tests using project-level coverage settings
dotnet test --collect:"XPlat Code Coverage"
```

## Coverage Reports Generated

After running the tests, the following reports are generated in the `TestResults/` directory:

### 1. Cobertura XML Report
- **File**: `coverage.cobertura.xml`
- **Purpose**: Machine-readable coverage data
- **Use Cases**: CI/CD pipelines, coverage analysis tools
- **Format**: XML with detailed line-by-line coverage information

### 2. HTML Report
- **File**: `index.html` (in coverage folder)
- **Purpose**: Human-readable visual coverage report
- **Features**: 
  - File tree navigation
  - Line-by-line coverage highlighting
  - Coverage percentages by file and method
  - Color-coded coverage indicators

### 3. JSON Report
- **File**: `coverage.json`
- **Purpose**: Programmatic access to coverage data
- **Use Cases**: Custom reporting, integration with other tools

## Coverage Metrics

The coverage reports include:

- **Line Coverage**: Percentage of code lines executed during tests
- **Branch Coverage**: Percentage of code branches taken during tests
- **Method Coverage**: Percentage of methods called during tests
- **File Coverage**: Coverage breakdown by individual source files

## Understanding Coverage Results

### High Coverage Areas
- **TokenCache**: Core caching functionality
- **TokenCacheRecord**: Token storage and management
- **SecureToken**: Secure token handling
- **TokenProviderBase**: Base token provider logic

### Areas to Monitor
- **Error Handling**: Exception paths and edge cases
- **Async Operations**: Cancellation token handling
- **Disposal Patterns**: Resource cleanup scenarios
- **Concurrent Access**: Thread safety mechanisms

## Coverage Goals

### Target Coverage: 90%+
- **Core Functionality**: 95%+ line coverage
- **Error Handling**: 85%+ branch coverage
- **Edge Cases**: 80%+ method coverage

### Areas Requiring High Coverage
- **Token Caching Logic**: Critical for performance
- **Security Operations**: Token handling and disposal
- **Async Operations**: Proper cancellation and error handling
- **Resource Management**: Memory and disposal patterns

## Troubleshooting Coverage Issues

### Common Problems

1. **No Coverage Reports Generated**
   - Ensure `coverlet.collector` package is installed
   - Check that `CollectCoverage` is set to `true`
   - Verify test execution completed successfully

2. **Incomplete Coverage Data**
   - Check exclusion patterns in project file
   - Ensure source files are accessible
   - Verify test assemblies are properly referenced

3. **Coverage Reports Not Opening**
   - Check file permissions in `TestResults` directory
   - Ensure HTML files are generated correctly
   - Try opening files manually from file explorer

### Debug Commands

```bash
# Check if coverlet collector is working
dotnet test --collect:"XPlat Code Coverage" --verbosity normal

# Run specific test category with coverage
dotnet test --filter "Category=TokenCache" --collect:"XPlat Code Coverage"

# Generate coverage without running tests
dotnet test --collect:"XPlat Code Coverage" --no-build
```

## Integration with CI/CD

### GitHub Actions Example
```yaml
- name: Run Tests with Coverage
  run: |
    dotnet test --settings coverlet.runsettings --collect:"XPlat Code Coverage" --results-directory TestResults
    
- name: Upload Coverage Reports
  uses: actions/upload-artifact@v3
  with:
    name: coverage-reports
    path: TestResults/
```

### Azure DevOps Example
```yaml
- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    arguments: '--settings coverlet.runsettings --collect:"XPlat Code Coverage" --results-directory TestResults'
    
- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'Cobertura'
    testResultsFiles: 'TestResults/**/*.xml'
```

## Best Practices

1. **Regular Coverage Monitoring**: Run coverage reports before each commit
2. **Coverage Thresholds**: Set minimum coverage requirements in CI/CD
3. **Coverage Trends**: Track coverage changes over time
4. **Quality Gates**: Use coverage as part of pull request requirements
5. **Documentation**: Keep coverage reports accessible to the team

## Additional Resources

- [Coverlet Documentation](https://github.com/coverlet-coverage/coverlet)
- [Cobertura Format](https://cobertura.github.io/cobertura/)
- [.NET Test Coverage](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage)
- [Code Coverage Best Practices](https://docs.microsoft.com/en-us/azure/devops/pipelines/test/code-coverage)
