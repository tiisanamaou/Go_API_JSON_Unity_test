using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textUI;

    // 別のスクリプトを呼び出す
    //[SerializeField,Tooltip("jsonファイルを入れる")]
    [SerializeField]
    GoJsonAPI goJsonAPIcs;

    public void OnPress()
    {
        Debug.Log("クリックされた");
        //textUI.text = "Sample Text";
        goJsonAPIcs.GetMethod();
        // アウトレット接続
        // 1秒遅延してから関数実行
        Invoke("TextText",1.0f);
    }

    public void TextText()
    {
        textUI.text = goJsonAPIcs.UserDataJson().UserName;
    }
}
