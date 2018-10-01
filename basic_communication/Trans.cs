﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Trans : MonoBehaviour {

    public string url = "127.0.0.1";
    public string port = ":3000";

    // Use this for initialization
    void Start()
    { }

    public void PostButtonClick(int param)
    {
        StartCoroutine(TestPost());
    }

    IEnumerator TestPost()
    {

        // Create a Web Form
        WWWForm form = new WWWForm();
        
        form.AddField("description","sendData");//description이라는 틀에 sendData라는 메시지를 담음.

        using (var w = UnityWebRequest.Post("http://localhost:3000/form_receiver", form))//url 입력-> 현재는 로컬 호스트+3000포트
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                Debug.Log(w.downloadHandler.text);
            }
        }
    }

}
