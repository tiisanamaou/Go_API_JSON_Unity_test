using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textUI;

    // 別のスクリプトを呼び出す
    public GoJsonAPI goJsonAPI;

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
        Debug.Log("クリックされた");
        //textUI.text = "Sample Text";
        //textUI.text = goJsonAPI.ApiText;
        Debug.Log(goJsonAPI.ApiText);
    }
}
