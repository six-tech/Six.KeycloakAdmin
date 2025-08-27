namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetAuthenticatorProvidersAsync(string realm)
  {
    var result = await _adminProvider.AuthenticationManagement.GetAuthenticatorProvidersAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetClientAuthenticatorProvidersAsync(string realm)
  {
    var result = await _adminProvider.AuthenticationManagement.GetClientAuthenticatorProvidersAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetAuthenticatorProviderConfigurationDescriptionAsync(string realm)
  {
    var providers = await _adminProvider.AuthenticationManagement.GetAuthenticatorProvidersAsync(realm);
    var providerId = providers.FirstOrDefault()?.FirstOrDefault(x => x.Key == "id").Value.ToString();
    if(providerId != null)
    {
      var result =
        await _adminProvider.AuthenticationManagement.GetAuthenticatorProviderConfigurationDescriptionAsync(realm, providerId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory(Skip = "Not working yet")]
  [InlineData("master")]
  public async Task GetAuthenticatorConfigurationAsync(string realm)
  {
    string configurationId = ""; //TODO
    if(configurationId != null)
    {
#pragma warning disable CS0618 // Type or member is obsolete
      var result = await _adminProvider.AuthenticationManagement.GetAuthenticatorConfigurationAsync(realm, configurationId);
#pragma warning restore CS0618 // Type or member is obsolete
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetAuthenticationExecutionAsync(string realm)
  {
    var flows = await _adminProvider.AuthenticationManagement.GetAuthenticationFlowsAsync(realm);
    var flowAlias = flows.FirstOrDefault()?.Alias;
    if(flowAlias != null)
    {
      var executions = await _adminProvider.AuthenticationManagement.GetAuthenticationFlowExecutionsAsync(realm, flowAlias);
      var executionId = executions.FirstOrDefault()?.Id;
      if(executionId != null)
      {
        var result = await _adminProvider.AuthenticationManagement.GetAuthenticationExecutionAsync(realm, executionId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetAuthenticationFlowsAsync(string realm)
  {
    var result = await _adminProvider.AuthenticationManagement.GetAuthenticationFlowsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetAuthenticationFlowExecutionsAsync(string realm)
  {
    var flows = await _adminProvider.AuthenticationManagement.GetAuthenticationFlowsAsync(realm);
    var flowAlias = flows.FirstOrDefault()?.Alias;
    if(flowAlias != null)
    {
      var result = await _adminProvider.AuthenticationManagement.GetAuthenticationFlowExecutionsAsync(realm, flowAlias);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetAuthenticationFlowByIdAsync(string realm)
  {
    var flows = await _adminProvider.AuthenticationManagement.GetAuthenticationFlowsAsync(realm);
    var flowId = flows.FirstOrDefault()?.Id;
    if(flowId != null)
    {
      var result = await _adminProvider.AuthenticationManagement.GetAuthenticationFlowByIdAsync(realm, flowId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetFormActionProvidersAsync(string realm)
  {
    var result = await _adminProvider.AuthenticationManagement.GetFormActionProvidersAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetFormProvidersAsync(string realm)
  {
    var result = await _adminProvider.AuthenticationManagement.GetFormProvidersAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetConfigurationDescriptionsForAllClientsAsync(string realm)
  {
    var result = await _adminProvider.AuthenticationManagement.GetConfigurationDescriptionsForAllClientsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetRequiredActionsAsync(string realm)
  {
    var result = await _adminProvider.AuthenticationManagement.GetRequiredActionsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetRequiredActionByAliasAsync(string realm)
  {
    var requiredActions = await _adminProvider.AuthenticationManagement.GetRequiredActionsAsync(realm);
    string? requiredActionAlias = requiredActions.FirstOrDefault()?.Alias;
    
    if(requiredActionAlias != null)
    {
      var result = await _adminProvider.AuthenticationManagement.GetRequiredActionByAliasAsync(realm, requiredActionAlias);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "AuthenticationManagement")]
  [Theory]
  [InlineData("master")]
  public async Task GetUnregisteredRequiredActionsAsync(string realm)
  {
    var result = await _adminProvider.AuthenticationManagement.GetUnregisteredRequiredActionsAsync(realm);
    Assert.NotNull(result);
  }
}
