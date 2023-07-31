using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoJsonAPI : MonoBehaviour
{
    // URLは環境に応じて変更
    string requestURL = "http://192.168.10.25:8080/get";

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

    public void GetMethod()
    {
        StartCoroutine(GetText());
    }

    // テキストファイルとして読み込む
    public IEnumerator GetText()
    {
        // GET Method
        var req = UnityWebRequest.Get(requestURL);
        yield return req.SendWebRequest();

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
    }
}