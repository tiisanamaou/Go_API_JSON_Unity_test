using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textUI;
    public Text uiUserRank;

    // �ʂ̃X�N���v�g���Ăяo��
    //[SerializeField,Tooltip("json�t�@�C��������")]
    [SerializeField]
    GetRequestcs goJsonAPIcs;
    //[SerializeField]
    // GoJsonAPI ServerScript;

    public async void OnPress()
    {
        Debug.Log("�N���b�N���ꂽ");
        textUI.text = "�ʐM��...";
        //await goJsonAPIcs.GetMethod();
        var er = await goJsonAPIcs.GetRequest();
        // �A�E�g���b�g�ڑ�

        if (er != null)
        {
            DisplayText();
            return;
        }
        textUI.text = "�ʐM�G���[";
    }

    public void DisplayText()
    {
        textUI.text = goJsonAPIcs.UserDataJson().UserName;
    }

    public async void OnPress2()
    {
        Debug.Log("POST�{�^��");
        uiUserRank.text = "�ʐM��...";
        var er = await goJsonAPIcs.GetRequest();

        if (er != null)
        {
            uiUserRank.text = goJsonAPIcs.UserDataJson().UserID;
            return;
        }
        textUI.text = "�ʐM�G���[";
    }
}
