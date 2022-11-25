using ConfigurationProvider.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json;

namespace ConfigurationProvider.Contracts
{
    public interface IStorageManager
    {
        public void SaveFile(string filePath, string content);
        public string? LoadFile(string filePath);
    }

    public class StorageManager : IStorageManager
    {
        public void SaveFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: {0}", ex.Message);
            }
        }

        public string? LoadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    var fileContent = File.ReadAllText(filePath);
                    return fileContent;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading file: {0}", ex.Message);
                }
            }
            return null;
        }
    }
}
