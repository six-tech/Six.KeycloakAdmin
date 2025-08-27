namespace Six.KeycloakAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public abstract class KeycloakAdminServiceBase
{
  protected readonly KeycloakAdminProviderBase InternalAdminProvider;

  protected KeycloakAdminServiceBase(KeycloakAdminProviderBase internalAdminProvider)
  {
    InternalAdminProvider = internalAdminProvider;
  }
}