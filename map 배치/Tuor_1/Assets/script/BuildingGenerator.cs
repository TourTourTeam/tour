using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour {
    public GameObject canvasObject;
    public GameObject transportManager;
    public GameObject dataManager;

    public int building_num;

	// Use this for initialization
	void Start () {
        canvasObject = GameObject.Find("Canvas");
        transportManager = GameObject.Find("TransportManager");
        dataManager = GameObject.Find("DataManager");

        /*  get building list from server*/
        BuildingListJson buildingListJson = new BuildingListJson();
        string map_name = (string)dataManager.GetComponent<StaticDataManager>().dataMap["map_name"];
        transportManager.GetComponent<Transport>().SendGet("/buildings/map/" + map_name, buildingListJson, (resultJson) =>
        {

            BuildingListJson result = (BuildingListJson)resultJson;
            building_num = int.Parse(result.length);

            foreach(BuildingJson b in result.data){
                GameObject prefab = Resources.Load("prefab/" + b.prefabName) as GameObject;
                GameObject buildingInstance = Instantiate(prefab) as GameObject;
                buildingInstance.transform.SetParent(canvasObject.transform);
                buildingInstance.transform.localPosition = new Vector3(float.Parse(b.y), float.Parse(b.x));
                buildingInstance.transform.localScale = new Vector3(1, 1, 1);
                buildingInstance.GetComponent<BuildingBehaviourScript>().setBuildingInfo(b);
                buildingInstance.SetActive(true);
                buildingInstance.layer = 2;
            }
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
