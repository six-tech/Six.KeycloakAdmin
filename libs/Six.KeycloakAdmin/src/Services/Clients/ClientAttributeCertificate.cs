using Six.KeycloakAdmin.Models.ClientAttributeCertificate;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class ClientAttributeCertificate : KeycloakAdminServiceBase
{
  public ClientAttributeCertificate(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<Certificate> GetKeyInfoAsync(string realm,
    string clientId,
    string attribute,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}")
      .GetJsonAsync<Certificate>(cancellationToken: cancellationToken)
      ;

  public async Task<byte[]> GetKeyStoreForClientAsync(string realm,
    string clientId,
    string attribute,
    KeyStoreConfig keyStoreConfig,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/download")
      .PostJsonAsync(keyStoreConfig, cancellationToken: cancellationToken)
      .ReceiveBytes()
      ;

  public async Task<Certificate> GenerateCertificateWithNewKeyPairAsync(string realm,
    string clientId,
    string attribute,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/generate")
      .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
      .ReceiveJson<Certificate>()
      ;

  public async Task<byte[]> GenerateCertificateWithNewKeyPairAndGetKeyStoreAsync(string realm,
    string clientId,
    string attribute,
    KeyStoreConfig keyStoreConfig,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/generate-and-download")
      .PostJsonAsync(keyStoreConfig, cancellationToken: cancellationToken)
      .ReceiveBytes()
      ;

  public async Task<Certificate> UploadCertificateWithPrivateKeyAsync(string realm,
    string clientId,
    string attribute,
    string fileName,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/upload")
      .PostMultipartAsync(content => content.AddFile(Path.GetFileName(fileName),
          Path.GetDirectoryName(fileName)),
        cancellationToken: cancellationToken)
      .ReceiveJson<Certificate>()
      ;

  public async Task<Certificate> UploadCertificateWithoutPrivateKeyAsync(string realm,
    string clientId,
    string attribute,
    string fileName,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/certificates/{attribute}/upload-certificate")
      .PostMultipartAsync(content => content.AddFile(Path.GetFileName(fileName),
          Path.GetDirectoryName(fileName)),
        cancellationToken: cancellationToken)
      .ReceiveJson<Certificate>()
      ;
}
