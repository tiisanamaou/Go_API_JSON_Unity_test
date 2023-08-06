using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textUI;

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
}
