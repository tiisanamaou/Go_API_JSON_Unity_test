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
    //[SerializeField]
    // GoJsonAPI ServerScript;

    public async void OnPress()
    {
        Debug.Log("クリックされた");
        textUI.text = "通信中...";
        //await goJsonAPIcs.GetMethod();
        await goJsonAPIcs.GetRequest();
        // アウトレット接続
        TextText();
    }

    public void TextText()
    {
        textUI.text = goJsonAPIcs.UserDataJson().UserName;
    }
}
