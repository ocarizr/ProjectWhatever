using UnityEngine;
using Security;

namespace Configuration
{
    public class ConfigReader
    {
        struct ConfigObject
        {
            public string SaveDataPath { get; private set; }
        }

        private ConfigObject? _config = null;

        public ConfigReader(string path)
        {
            var decryptor = new Crypto();
            _config = JsonUtility.FromJson<ConfigObject>(decryptor.DecryptFile(path));
        }

        public T GetItem<T>(string item)
        {
            T result = default;
            if (_config != null)
            {
                result = (T) _config.GetType().GetField(item).GetValue(null);
            }

            return result;
        }
    }
}
