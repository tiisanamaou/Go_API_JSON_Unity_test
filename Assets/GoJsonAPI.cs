using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoJsonAPI : MonoBehaviour
{

    // URL�͊��ɉ����ĕύX
    string requestURL = "http://192.168.10.18:8080/api";

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

            // �܂��́A���ʂ��o�C�i���f�[�^�Ƃ��Ď擾���܂�
            // byte[] results = www.downloadHandler.data;
        }
    }
}