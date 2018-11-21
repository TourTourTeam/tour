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
        array.Add(new KeyValuePair<string, string>("pw", loginWindow.GetComponent<loginWindowBehavior>().passwordField.text));

        /*
         * array 에 id와 password를 받음. 통과하면 로그인 성공
        */
        UserJson resultJson = new UserJson();
        transportManager.GetComponent<Transport>().SendPost("/users/login", array, resultJson, (jsonObject) =>
        {
            UserJson result = (UserJson)jsonObject;
            if(result.success.Equals("true")){
                dataManager.GetComponent<StaticDataManager>().dataMap.Add("map_name", result.map);
                dataManager.GetComponent<StaticDataManager>().dataMap.Add("user", result);

                SceneManager.LoadScene("Scenes/" + result.map + "Scene");
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
