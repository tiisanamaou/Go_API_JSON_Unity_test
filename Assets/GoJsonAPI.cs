using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoJsonAPI : MonoBehaviour
{

    // URL�͊��ɉ����ĕύX
    string requestURL = "http://192.168.10.25:8080/api";

    // JSON
    [Serializable]
    public class JsonText
    {
        public string status;
        public string message;
        public string returnCode;
    }

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
            JsonText jsonText = JsonUtility.FromJson<JsonText>(www.downloadHandler.text);
            // JSON�̒���message�����o��
            Debug.Log(jsonText.message);
        }
    }
}