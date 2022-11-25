namespace ConfigurationProvider.Contracts;

public interface IEncryptionManager
{
    public string Encrypt(string contentToEncrypt);
    public string Decrypt(string contentToDecrypt);
}