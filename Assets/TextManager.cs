using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textUI;
    public Text uiUserRank;

    // 別のスクリプトを呼び出す
    //[SerializeField,Tooltip("jsonファイルを入れる")]
    [SerializeField]
    GetRequestcs goJsonAPIcs;
    //[SerializeField]
    // GoJsonAPI ServerScript;

    public async void OnPress()
    {
        Debug.Log("クリックされた");
        textUI.text = "通信中...";
        //await goJsonAPIcs.GetMethod();
        var er = await goJsonAPIcs.GetRequest();
        // アウトレット接続

        if (er != null)
        {
            DisplayText();
            return;
        }
        textUI.text = "通信エラー";
    }

    public void DisplayText()
    {
        textUI.text = goJsonAPIcs.UserDataJson().UserName;
    }

    public async void OnPress2()
    {
        Debug.Log("POSTボタン");
        uiUserRank.text = "通信中...";
        var er = await goJsonAPIcs.GetRequest();

        if (er != null)
        {
            uiUserRank.text = goJsonAPIcs.UserDataJson().UserID;
            return;
        }
        textUI.text = "通信エラー";
    }
}
