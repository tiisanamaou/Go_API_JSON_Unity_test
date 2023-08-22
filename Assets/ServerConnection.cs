using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ServerConnection : MonoBehaviour
{
    //const string requestURL = "http://192.168.10.18:8080/get";
    //const string requestURL = "http://192.168.10.18:8080/post";
    const string requestURL = "http://192.168.10.18:8080";

    const string GetRequestURL = requestURL + "/get";
    const string PostRequestURL = requestURL + "/post";

    //
    public class UserDataJson
    {
        public string UserID;
        public int UserRank;
        public string UserName;
    }
    //
    UserDataJson userDataJson = new UserDataJson();
    UserDataJson postUserData = new UserDataJson();

    /// <summary>
    /// �Q�b�^�[�A�T�[�o�[�����JSON�f�[�^
    /// </summary>
    /// <returns></returns>
    public UserDataJson UserDataFromServer
    {
        get { return userDataJson; }
    }

    // Start is called before the first frame update
    async void Start()
    {
        await RequestPostMethod();
        Debug.Log("�ʐM��������");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async UniTask RequestGetMethod()
    {
        UnityWebRequest req = new UnityWebRequest(GetRequestURL);
        req.downloadHandler = new DownloadHandlerBuffer();
        // Method�ݒ�
        req.method = "GET";
        //
        await ServerCommunication(req);
        //
    }

    public async UniTask RequestPostMethod()
    {
        //
        postUserData.UserID = "0035";
        postUserData.UserRank = 10;
        postUserData.UserName = "username";
        //
        var json = JsonUtility.ToJson(postUserData);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //
        UnityWebRequest req = new UnityWebRequest(PostRequestURL);
        req.uploadHandler = new UploadHandlerRaw(postData);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        req.timeout = 5;
        // Method�ݒ�
        req.method = "POST";
        //
        await ServerCommunication(req);
        //
    }

    /// <summary>
    /// API�T�[�o�[�ƒʐM����ׂ̊֐�
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    async UniTask ServerCommunication(UnityWebRequest req)
    {
        // ��O�����E���M
        try
        {
            //await req.SendWebRequest();
            await req.SendWebRequest()
                .ToUniTask(Progress.Create<float>(x =>
                {
                    //x = req.downloadProgress;
                    Debug.Log("DL�i��" + $"{x * 100} %");
                }));
        }
        catch (UnityWebRequestException)
        {
            Debug.Log("��O�����F�T�[�o�[���_�E�����Ă��܂�");
            Debug.Log(req.result);
            Debug.Log(req.responseCode);
            return;
        }
        // �ʐM�������������m�F
        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("�ʐM�G���[");
            Debug.Log(req.error);
            return;
        }
        //
        var header = req.GetResponseHeader(name: "Content-Type");
        Debug.Log(header);
        // DL�f�[�^�m�F
        Debug.Log(req.responseCode);
        Debug.Log(req.downloadedBytes);
        Debug.Log(req.downloadHandler.text);
        // JSON�f�[�^�֕ϊ�
        userDataJson = JsonUtility.FromJson<UserDataJson>(req.downloadHandler.text);
        Debug.Log(userDataJson);
    }
}
