using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  Login Scene을 관리하는 디렉터   */
public class LoginDirector : MonoBehaviour {
    GameObject loginWindow;
    GameObject transportManager;
    GameObject dataManager;

	// Use this for initialization
	void Start () {
        loginWindow = GameObject.Find("loginWindow");
        transportManager = GameObject.Find("TransportManager");
        dataManager = GameObject.Find("DataManager");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /*  로그인 시도  */
    public void tryLogin(){
        ArrayList array = new ArrayList();
        array.Add(new KeyValuePair<string, string>("id", loginWindow.GetComponent<loginWindowBehavior>().idField.text));
        array.Add(new KeyValuePair<string, string>("pw", loginWindow.GetComponent<loginWindowBehavior>().passwordField.text));

        /*
         * array 에 id와 password를 받음. 통과하면 로그인 성공
        */
        ResultJson resultJson = new ResultJson();
        transportManager.GetComponent<Transport>().SendPost("/users/login", array, resultJson, (jsonObject) =>
        {
            ResultJson result = (ResultJson)jsonObject;
            if(result.success.Equals("true")){
                dataManager.GetComponent<StaticDataManager>().dataList.Add(result.map);
                SceneManager.LoadScene("Scenes/SampleScene");
            }
            else{
                Debug.Log("응 아니야~");
            }
        });
    }

    /*  회원가입 시도  */
    public void tryNewAccount(){
        ArrayList array = new ArrayList();
        array.Add(new KeyValuePair<string, string>("id", loginWindow.GetComponent<loginWindowBehavior>().idField.text));
        array.Add(new KeyValuePair<string, string>("pw", loginWindow.GetComponent<loginWindowBehavior>().passwordField.text));

        ResultJson resultJson = new ResultJson();
        transportManager.GetComponent<Transport>().SendPost("/users/new", array, resultJson, (jsonObject) =>
        {
            ResultJson result = (ResultJson)jsonObject;
            if (result.success.Equals("true"))
            {
                Debug.Log("로그인 하세요!");
            }
            else
            {
                Debug.Log("오류 ....");
            }
        });
    }
}
