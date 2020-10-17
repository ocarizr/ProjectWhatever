using Configuration;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    private ConfigReader _configReader;

    public ConfigReader ConfigurationReader => _configReader;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance == this) return;
            Destroy(gameObject);
        }

        _configReader = new ConfigReader("");
    }
}
