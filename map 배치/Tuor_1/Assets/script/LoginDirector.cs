using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  Login Scene을 관리하는 디렉터   */
public class LoginDirector : MonoBehaviour {
    GameObject camera;
    GameObject canvas;
    GameObject loginWindow;
    GameObject transportManager;
    GameObject dataManager;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(960, 540, -100);
        camera.transform.localScale = new Vector3(91.062f, 24.3752f, 1.10118f);

        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 1080);
        canvas.GetComponent<RectTransform>().position = new Vector3(960, 540, 0);

        canvas = GameObject.Find("Canvas");

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
        array.Add(new KeyValuePair<string, string>("password", loginWindow.GetComponent<loginWindowBehavior>().passwordField.text));

        /*
         * array 에 id와 password를 받음. 통과하면 로그인 성공
        */
        SignJson resultJson = new SignJson();
        transportManager.GetComponent<Transport>().SendPost("/login", array, resultJson, (jsonObject) =>
        {
            SignJson result = (SignJson)jsonObject;
            if(result.success.Equals("true")){
                
                transportManager.GetComponent<Transport>().SendGet("/api/user", new UserResultJson(), (userJsonObject) =>
                {
                    UserResultJson user_result = (UserResultJson)userJsonObject;
                    dataManager.GetComponent<StaticDataManager>().dataMap.Add("map_name", user_result.data[0].cur_map_name);
                    dataManager.GetComponent<StaticDataManager>().dataMap.Add("user", user_result.data[0]);

                    Debug.Log(user_result.data[0].cur_map_name);

                    SceneManager.LoadScene("Scenes/" + user_result.data[0].cur_map_name + "Scene");
                });
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
        array.Add(new KeyValuePair<string, string>("password", loginWindow.GetComponent<loginWindowBehavior>().passwordField.text));
        array.Add(new KeyValuePair<string, string>("name", "test"));


        SignJson signJson = new SignJson();
        transportManager.GetComponent<Transport>().SendPost("/signup", array, signJson, (jsonObject) =>
        {
            SignJson result = (SignJson)jsonObject;
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
