using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFindObj : MonoBehaviour
{
    PostRequest postRequest;

    // Start is called before the first frame update
    void Start()
    {
        postRequest = GetComponent<PostRequest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        Debug.Log("�{�^���������ꂽ");
        var postData = postRequest.PostJson();
        Debug.Log(postData);
    }
}
