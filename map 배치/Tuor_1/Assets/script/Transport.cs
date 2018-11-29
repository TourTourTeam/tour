using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;

public class Transport : MonoBehaviour
{

    public string url = "ec2-3-17-30-224.us-east-2.compute.amazonaws.com";
    public string port = "3000";
    public object resultObject;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    { }

    public void SendPost(string path, ArrayList fields, object jsonObject, Action<object> action)
    {
        StartCoroutine(TestPost(path, fields, jsonObject, action));
    }

    public void SendGet(string path, object jsonObject, Action<object> action)
    {
        StartCoroutine(TestGet(path, jsonObject, action));
    }

    IEnumerator TestPost(string path, ArrayList fields, object jsonObject, Action<object> action)
    {

        // Create a Web Form
        WWWForm form = new WWWForm();

        foreach(KeyValuePair<string, string> f in fields)
        {
            form.AddField(f.Key, f.Value);
        }

        Debug.Log(url + ":" + port + path);

        using (var w = UnityWebRequest.Post(url + ":" + port + path, form))//url 입력-> 현재는 로컬 호스트+3000포트
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                /*  비동기 처리  */
                JsonUtility.FromJsonOverwrite(w.downloadHandler.text, jsonObject);
                if (action != null)
                    action(jsonObject);

                Debug.Log(w.downloadHandler.text);
            }
        }
    }

    IEnumerator TestGet(string path, object jsonObject, Action<object> action)
    {
        Debug.Log(url + ":" + port + path);

        using (UnityWebRequest www = UnityWebRequest.Get(url + ":" + port + path))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("err" + www.error);
            }
            else
            {
                /*  비동기 처리  */
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, jsonObject);
                if (action != null)
                    action(jsonObject);

                Debug.Log("receive" + www.downloadHandler.text);
             }
        }
    }
}
