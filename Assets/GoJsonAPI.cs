using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using static GoJsonAPI;

public class GoJsonAPI : MonoBehaviour
{

    // URLは環境に応じて変更
    string requestURL = "http://192.168.10.25:8080/get";

    // JSON
    [Serializable]
    public class JsonText
    {
        //public int status;
        //public string message;
        //public string returnCode;
        //public string userData;

        public string UserID;
        public int UserRank;
        public string UserName;

    }

    //public string ApiText;

    JsonText jsonText;

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(GetText());
    }

    // テキストファイルとして読み込む
    [System.Obsolete]
    IEnumerator GetText()
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
            jsonText = JsonUtility.FromJson<JsonText>(req.downloadHandler.text);
            Debug.Log(jsonText.UserName);
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

    /// <summary>
    /// ゲッター
    /// </summary>
    /// <returns></returns>
    public JsonText GetJosonText()
    {
        return jsonText;
    }
}