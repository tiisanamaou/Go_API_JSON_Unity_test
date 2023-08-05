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
    // POST����f�[�^�iRequest Body�j
    private sealed class Data
    {
        //[DataMember(Name = "id")]
        public string UserID = "0005";
        //[DataMember(Name ="rank")]
        public int UserRank = 20;
        //[DataMember(Name ="name")]
        public string UserName = "�܂��܂�";
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

        // ��O����
        try
        {
            await req.SendWebRequest();
        }
        catch (UnityWebRequestException)
        {
            Debug.Log("��O�����F�T�[�o�[���_�E�����Ă��܂�");
            return;
        }

        // �X�e�[�^�X�R�[�h�m�F
        if (req.responseCode == 200)
        {
            Debug.Log("200");
        }

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("POST�����I");
            //Debug.Log(req.downloadHandler.text);
            responseData = req.downloadHandler.text;
        }
        else
        {
            Debug.Log("�G���[");
            Debug.Log(req.error.ToString());
        }
    }
}
