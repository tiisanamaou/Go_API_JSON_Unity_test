using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoJsonAPI : MonoBehaviour
{
    // URL�͊��ɉ����ĕύX
    string requestURL = "http://192.168.10.25:8080/get";

    // JSON
    [Serializable]
    public class JsonRequest
    {
        public string UserID;
        public int UserRank;
        public string UserName;
    }

    JsonRequest userJson;

    /// <summary>
    /// �Q�b�^�[
    /// </summary>
    /// <returns></returns>
    public JsonRequest UserDataJson()
    {
        return userJson;
    }

    //
    void Start()
    {

    }

    public void GetMethod()
    {
        StartCoroutine(GetText());
    }

    // �e�L�X�g�t�@�C���Ƃ��ēǂݍ���
    public IEnumerator GetText()
    {
        // GET Method
        var req = UnityWebRequest.Get(requestURL);
        yield return req.SendWebRequest();

        switch (req.result)
        {
            case UnityWebRequest.Result.InProgress:
            Debug.Log("���N�G�X�g��");
            break;

            case UnityWebRequest.Result.Success:
            Debug.Log("���N�G�X�g����");
            Debug.Log(req.downloadHandler.text);
            userJson = JsonUtility.FromJson<JsonRequest>(req.downloadHandler.text);
            Debug.Log(userJson.UserName);
            break;

            case UnityWebRequest.Result.ConnectionError:
            Debug.Log("Connection:�G���[");
            Debug.Log(req.error);
            break;

            case UnityWebRequest.Result.ProtocolError:
            Debug.Log("Protocol:�G���[");
            break;

            case UnityWebRequest.Result.DataProcessingError:
            Debug.Log("DataProcess:�G���[");
            break;
        }
    }
}