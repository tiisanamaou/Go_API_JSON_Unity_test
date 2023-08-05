using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class PostRequest : MonoBehaviour
{
    [Serializable]
    // POSTするデータ（Request Body）
    private sealed class Data
    {
        //[DataMember(Name = "id")]
        public string UserID = "0005";
        //[DataMember(Name ="rank")]
        public int UserRank = 20;
        //[DataMember(Name ="name")]
        public string UserName = "まおまお";
    }

    Data data = new Data();

    string responseData;

    private async void Start()
    {
        //
        await RequestJson();
        //Debug.Log(data.UserName);
        Debug.Log(responseData);
    }

    private async UniTask RequestJson()
    {
        var url = "http://192.168.10.23:8080/post";
        //var data = new Data();
        var json = JsonUtility.ToJson(data);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //
        UnityWebRequest req = new UnityWebRequest(url, "POST");
        req.uploadHandler = new UploadHandlerRaw(postData);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        req.timeout = 10;
        //await req.SendWebRequest();

        // 例外処理
        try
        {
            await req.SendWebRequest();
        }
        catch (UnityWebRequestException)
        {
            Debug.Log("例外処理：サーバーがダウンしています");
            return;
        }

        // ステータスコード確認
        if (req.responseCode == 200)
        {
            Debug.Log("200");
        }

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("POST成功！");
            //Debug.Log(req.downloadHandler.text);
            responseData = req.downloadHandler.text;
        }
        else
        {
            Debug.Log("エラー");
            Debug.Log(req.error.ToString());
        }
    }
}
