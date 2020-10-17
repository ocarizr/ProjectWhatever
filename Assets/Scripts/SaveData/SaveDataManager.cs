using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Security;

namespace SaveData
{
    public class SaveDataManager : MonoBehaviour
    {
        private string _dataPath;

        private void Start()
        {
            _dataPath = Manager.Instance.ConfigurationReader.GetItem<string>("SaveDataPath");
        }

        // Start is called before the first frame update
        public void LoadSaveData()
        {
            StartCoroutine(DownloadSaveData(_dataPath, ReadSaveData));
        }


        public void UpdateSaveData(string saveData)
        {
            StartCoroutine(UploadSaveData(_dataPath, saveData));
        }

        private void ReadSaveData(string saveData)
        {

        }

        private IEnumerator DownloadSaveData(string url, Action<string> callback)
        {
            using (var webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError)
                {
                    Debug.Log($"Failed to download Saved Data. Error: {webRequest.error}.");
                }
                else
                {
                    var decryptor = new Crypto();
                    var result = decryptor.DecryptData(webRequest.downloadHandler.data);
                    callback(result);
                }
            }
        }

        private IEnumerator UploadSaveData(string url, string saveData)
        {
            throw new NotImplementedException();
        }
    }
}
