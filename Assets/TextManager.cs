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
    GoJsonAPI goJsonAPI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        Debug.Log("�N���b�N���ꂽ");
        //textUI.text = "Sample Text";
        //textUI.text = goJsonAPI.ApiText;
        textUI.text = goJsonAPI.GetJosonText().UserName;
        //Debug.Log(goJsonAPI.ApiText);
    }
}
