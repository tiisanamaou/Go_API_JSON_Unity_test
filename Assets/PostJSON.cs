using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class PostJSON : MonoBehaviour
{
    [Serializable]
    // POSTするデータ（Request Body）
    private sealed class Data
    {
        public int id = 25;
        public string name = "テストデータ";
        public int loginData = 20;
    }

    //private void Awake()
    private void Start()
    {
        //var url = "http://192.168.10.25:8080/json";
        var url = "http://192.168.10.25:8080/post";
        var data = new Data();
        var json = JsonUtility.ToJson(data);
        // Add
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);

        // Add
        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();

        operation.completed += _ =>
        {
            Debug.Log(operation.isDone);
            Debug.Log(request.downloadHandler.text);
            //Debug.Log(operation.webRequest.downloadHandler.text);
        };
    }
}
