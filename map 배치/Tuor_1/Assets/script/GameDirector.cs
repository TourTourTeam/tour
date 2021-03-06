﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    GameObject camera;
    GameObject canvas;

    GameObject transportManager;

    public GameObject mapSaid;
    public GameObject buildingSaid;
    public GameObject buildingOwner;
    public GameObject characterSaid;

    GameObject dataManager;
    public int layer;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(960, 540, -100);
        camera.transform.localScale = new Vector3(91.062f, 24.3752f, 1.10118f);

        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 1080);
        canvas.GetComponent<RectTransform>().position = new Vector3(960, 540, 0);
        canvas.transform.SetAsLastSibling();

        //this.mapSaid = GameObject.Find("MapSaid");
        this.mapSaid.SetActive(false);

        //this.buildingSaid = GameObject.Find("BuildingSaid");
        this.buildingSaid.SetActive(false);

        //this.buildingOwner = GameObject.Find("BuildingOwnerSaid");
        this.buildingOwner.SetActive(false);

        //this.characterSaid = GameObject.Find("CharacterSaid");
        this.characterSaid.SetActive(false);


        this.dataManager = GameObject.Find("DataManager");

        this.transportManager = GameObject.Find("TransportManager");

    }

    public void deactiveAllBox()
    {
        deactivateMapSaid();
        deactivateBuildingSaid();
        deactivateBuildingOwnerSaid();
        deactiveCharacterSaid();
    }

    public void activeCharacterSaid()
    {
        deactiveAllBox();
        this.characterSaid.transform.SetAsLastSibling();
        this.characterSaid.transform.localPosition = new Vector3(0, -166, -50);
        this.characterSaid.transform.localScale = new Vector3(56, 50, 1);
        this.characterSaid.SetActive(true);
    }


    public void deactiveCharacterSaid()
    {
        this.characterSaid.SetActive(false);
    }

    /*  빌딩 말풍선을 보이게 함  */
    public void activateBuildingSaid(BuildingJson info){
        deactiveAllBox();
        this.buildingSaid.transform.SetAsLastSibling();
        this.buildingSaid.GetComponent<BuildingSaidScript>().setInfo(info);
        this.buildingSaid.transform.localPosition = new Vector3(0, -166,-50);
        this.buildingSaid.transform.localScale = new Vector3(56, 50, 1);
        this.buildingSaid.SetActive(true);
    }

    /*  빌딩 말풍선을 안보이게 함 */
    public void deactivateBuildingSaid(){
        this.buildingSaid.SetActive(false);
    }

    public void activateBuildingOnwerSaid(BuildingJson info){
        deactiveAllBox();
        this.buildingOwner.transform.SetAsLastSibling();
        this.buildingOwner.GetComponent<BuildingOwnerScript>().setInfo(info);
        this.buildingOwner.transform.localPosition = new Vector3(0, -166, -50);
        this.buildingOwner.transform.localScale = new Vector3(56, 50, 1);
        this.buildingOwner.SetActive(true);
    }

    public void deactivateBuildingOwnerSaid(){
        this.buildingOwner.SetActive(false);
    }

    /*  맵 말풍선을 보이게 함    */
    public void activateMapSaid(){
        deactiveAllBox();
        this.mapSaid.transform.SetAsLastSibling();
        this.mapSaid.transform.localPosition = new Vector3(-1, -30, -50);
        this.mapSaid.transform.localScale = new Vector3(40, 40, 1);
        this.mapSaid.SetActive(true);
    }

    /*  맵 말풍선을 숨김   */
    public void deactivateMapSaid(){
        this.mapSaid.SetActive(false);
    }


    public void changeMap(string map_name){
        dataManager.GetComponent<StaticDataManager>().dataMap["map_name"] = map_name;
        SceneManager.LoadScene("Scenes/" + map_name + "Scene");
    }


    public void mapSearch(){
        MapListJson emptyJson = new MapListJson();
        transportManager.GetComponent<Transport>().SendGet("/maps", emptyJson, (resultJson) =>
        {
            MapListJson result = (MapListJson)resultJson;
            string testText = "";
            foreach(MapJson s in result.data){
                testText += s.name + " , ";
            }
            Debug.Log(testText.ToString());
            this.mapSaid.GetComponent<MapSaidScript>().setUpText(testText);
        });
    }


    public void getUserData(){
        UserJson user = (UserJson)dataManager.GetComponent<StaticDataManager>().dataMap["user"];
        transportManager.GetComponent<Transport>().SendGet("/api/user/" + user.id, new UserJson(), (result) =>
        {
            dataManager.GetComponent<StaticDataManager>().dataMap["user"] = (UserJson)result;
        });
    }

    public void testUserData(){
        UserJson user = (UserJson)this.dataManager.GetComponent<StaticDataManager>().dataMap["user"];
        user.status.level = "100";
        string json = JsonUtility.ToJson(user);
        Debug.Log(json);

        ArrayList array = new ArrayList();
        array.Add(new KeyValuePair<string, string>("update", json));

        Debug.Log(this.transportManager);
        transportManager.GetComponent<Transport>().SendPost("/api/user/update/" + user.id, array, new UserResultJson(), (result) =>
        {
            Debug.Log(result);
        });

    }

    // Update is called once per frame
    void Update () {
		
	}

}
