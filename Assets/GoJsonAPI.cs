using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoJsonAPI : MonoBehaviour
{

    // URLは環境に応じて変更
    string requestURL = "http://192.168.10.25:8080/api";

    // JSON
    [Serializable]
    public class JsonText
    {
        public string status;
        public string message;
        public string returnCode;
    }

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(GetText());
    }

    // テキストファイルとして読み込む
    [System.Obsolete]
    IEnumerator GetText()
    {

        UnityWebRequest www = UnityWebRequest.Get(requestURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // 結果をテキストとして表示します
            Debug.Log(www.downloadHandler.text);

            // JSONをC#オブジェクトへ変換
            JsonText jsonText = JsonUtility.FromJson<JsonText>(www.downloadHandler.text);
            // JSONの中のmessageを取り出し
            Debug.Log(jsonText.message);
        }
    }
}