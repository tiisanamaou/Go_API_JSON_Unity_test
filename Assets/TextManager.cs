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

    public void OnPress()
    {
        Debug.Log("�N���b�N���ꂽ");
        goJsonAPIcs.GetMethod();
        // �A�E�g���b�g�ڑ�
        // 1�b�x�����Ă���֐����s
        Invoke("TextText",1.0f);
        textUI.text = "�ʐM��...";
    }

    public void TextText()
    {
        textUI.text = goJsonAPIcs.UserDataJson().UserName;
    }
}
