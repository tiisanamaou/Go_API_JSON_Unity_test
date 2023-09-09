using Cysharp.Threading.Tasks;
using System;
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
        public string Password = "Password";
    }

    Data data = new Data();

    string responseData;

    private async void Start()
    {
        await RequestJson();
        Debug.Log(responseData);
    }

    private async UniTask RequestJson()
    {
        var url = "http://192.168.10.18:8080/post";
        //var data = new Data();
        var json = JsonUtility.ToJson(data);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //
        //UnityWebRequest req = new UnityWebRequest(url, "POST");
        //
        UnityWebRequest req = new UnityWebRequest(url);
        req.method = "POST";
        //req.method = "PUT";
        //
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
            if (req.responseCode == 400)
            {
                Debug.Log("400");
            }
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
            //
            ulong size = 0;
            var header = req.GetResponseHeader("Content-Length");
            //1�t���[���ڂ�null�����肤��̂�null�`�F�b�N������
            if (header != null)
            {
                ulong.TryParse(header, out size);
            }
            Debug.Log(size+"byte");
            //
        }
        else
        {
            Debug.Log("�G���[");
            Debug.Log(req.error.ToString());
        }
    }

    /// <summary>
    /// POST�f�[�^�E�Q�b�^�[
    /// </summary>
    /// <returns></returns>
    public string PostJson()
    {
        return responseData;
    }
}
