using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetJSON : MonoBehaviour
{
    // URL�͊��ɉ����ĕύX
    string requestURL = "http://192.168.10.25:8080/get";

    // JSON
    [Serializable]
    public class JsonText
    {
        public string UserID;
        public int UserRank;
        public string UserName;
    }

    //public string ApiText;

    JsonText jsonText;

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(GetText());
    }

    // �e�L�X�g�t�@�C���Ƃ��ēǂݍ���
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
            // ���ʂ��e�L�X�g�Ƃ��ĕ\�����܂�
            Debug.Log(www.downloadHandler.text);

            // JSON��C#�I�u�W�F�N�g�֕ϊ�
            //JsonText jsonText = JsonUtility.FromJson<JsonText>(www.downloadHandler.text);
            jsonText = JsonUtility.FromJson<JsonText>(www.downloadHandler.text);
            // JSON�̒���message�����o��
            Debug.Log(jsonText.UserName);
            //ApiText = jsonText.message;
        }
    }
}
