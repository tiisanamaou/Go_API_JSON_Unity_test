using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class GetRequestcs : MonoBehaviour
{
    // URLは環境に応じて変更
    string requestURL = "http://192.168.10.18:8080/get";

    // JSON
    [Serializable]
    public class JsonRequest
    {
        public string UserID;
        public int UserRank;
        public string UserName;
    }

    JsonRequest userJson;

    /// <summary>
    /// ゲッター
    /// </summary>
    /// <returns></returns>
    public JsonRequest UserDataJson()
    {
        return userJson;
    }

    //
    void Start()
    {

    }

    public async UniTask<string> GetRequest()
    {
        var req = UnityWebRequest.Get(requestURL);
        // 例外処理
        try
        {
            await req.SendWebRequest();
        }
        catch (UnityWebRequestException)
        {
            Debug.Log("例外処理：サーバーがダウンしています");
            return null;
        }

        Debug.Log(req.downloadedBytes);
        //var header = req.GetRequestHeader("Content-Length");
        ulong size = 0;
        var header = req.GetRequestHeader(name: "Content-Length");
        if (header != null)
        {
            ulong.TryParse(header, out size);
        }
        Debug.Log(header);
        Debug.Log(size);

        switch (req.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("リクエスト中");
                break;

            case UnityWebRequest.Result.Success:
                Debug.Log("リクエスト成功");
                Debug.Log(req.downloadHandler.text);
                userJson = JsonUtility.FromJson<JsonRequest>(req.downloadHandler.text);
                Debug.Log(userJson.UserName);
                break;

            case UnityWebRequest.Result.ConnectionError:
                Debug.Log("Connection:エラー");
                Debug.Log(req.error);
                break;

            case UnityWebRequest.Result.ProtocolError:
                Debug.Log("Protocol:エラー");
                break;

            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log("DataProcess:エラー");
                break;
        }
        //return req.downloadHandler.text;
        //return userJson.UserName;
        return userJson.UserID;
    }
}