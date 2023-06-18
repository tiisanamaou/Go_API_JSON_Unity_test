using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoJsonAPI : MonoBehaviour
{

    // URLは環境に応じて変更
    string requestURL = "http://192.168.10.18:8080/api";

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

            // または、結果をバイナリデータとして取得します
            // byte[] results = www.downloadHandler.data;
        }
    }
}