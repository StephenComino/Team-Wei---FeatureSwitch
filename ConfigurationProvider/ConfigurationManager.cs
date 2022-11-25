using ConfigurationProvider.Contracts;
using ConfigurationProvider.Models;
using Newtonsoft.Json;

namespace ConfigurationProvider
{
    public class ConfigurationManager : IConfigurationManager
    {
        public void SaveConfigToFile(string filePath, FeatureConfiguration config)
        {
            var serializedConfig = JsonConvert.SerializeObject(config);
            //Can encrypt at this stage before sending off to write file
            //serializedConfig = _EncryptionManager.encrypt(serializedConfig);
            try
            {
                File.WriteAllText(filePath, serializedConfig);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: {0}", ex.Message);
            }
            
        }

        public FeatureConfiguration LoadConfigFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    var fileContent = File.ReadAllText(filePath);
                    //Should decrypt at this stage if wanted
                    //fileContent = _EncryptionManager.decrypt(fileContent);
                    return JsonConvert.DeserializeObject<FeatureConfiguration>(fileContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading file: {0}", ex.Message);
                }


            }
            return null!;
        }
    }
}
