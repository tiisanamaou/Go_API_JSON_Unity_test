using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetJSON : MonoBehaviour
{
    // URLは環境に応じて変更
    string requestURL = "http://192.168.10.25:8080/get";

    // JSON
    [Serializable]
    public class JsonText
    {
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
            //JsonText jsonText = JsonUtility.FromJson<JsonText>(www.downloadHandler.text);
            jsonText = JsonUtility.FromJson<JsonText>(www.downloadHandler.text);
            // JSONの中のmessageを取り出し
            Debug.Log(jsonText.UserName);
            //ApiText = jsonText.message;
        }
    }
}
