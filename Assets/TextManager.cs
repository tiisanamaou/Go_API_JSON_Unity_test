using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textUI;

    // �ʂ̃X�N���v�g���Ăяo��
    //[SerializeField,Tooltip("json�t�@�C��������")]
    [SerializeField]
    GoJsonAPI goJsonAPIcs;
    //[SerializeField]
    // GoJsonAPI ServerScript;

    public async void OnPress()
    {
        Debug.Log("�N���b�N���ꂽ");
        textUI.text = "�ʐM��...";
        //await goJsonAPIcs.GetMethod();
        await goJsonAPIcs.GetRequest();
        // �A�E�g���b�g�ڑ�
        TextText();
    }

    public void TextText()
    {
        textUI.text = goJsonAPIcs.UserDataJson().UserName;
    }
}
