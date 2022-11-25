using ConfigurationProvider.Contracts;
using ConfigurationProvider.Models;
using Newtonsoft.Json;

namespace ConfigurationProvider
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IStorageManager _storageManager;
        private readonly IEncryptionManager _encryptionManager;

        public ConfigurationManager(IStorageManager _storageManager, IEncryptionManager encryptionManager)
        {
            this._storageManager = _storageManager;
            _encryptionManager = encryptionManager;
        }
        public void SaveConfigToFile(string filePath, FeatureConfiguration config)
        {
            var serializedConfig = JsonConvert.SerializeObject(config);
            var encryptedSerializedConfig = _encryptionManager.Encrypt(serializedConfig);
            _storageManager.SaveFile(filePath, encryptedSerializedConfig);

        }

        public FeatureConfiguration? LoadConfigFromFile(string filePath)
        {
            var encrptedSerliazedConfig = _storageManager.LoadFile(filePath);
            if (encrptedSerliazedConfig == null)
                return null;
            var SerializedConfig = _encryptionManager.Decrypt(encrptedSerliazedConfig);
            return JsonConvert.DeserializeObject<FeatureConfiguration>(SerializedConfig);
        }
    }
}
