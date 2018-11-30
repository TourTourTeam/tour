using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour {
    public GameObject canvasObject;
    public GameObject transportManager;
    public GameObject dataManager;

    public GameObject mapButton;
    public GameObject charactorButton;

    public int building_num;

	// Use this for initialization
	void Start () {
        canvasObject = GameObject.Find("Canvas");
        transportManager = GameObject.Find("TransportManager");
        dataManager = GameObject.Find("DataManager");


        /*  get building list from server*/
        string map_name = (string)dataManager.GetComponent<StaticDataManager>().dataMap["map_name"];
        transportManager.GetComponent<Transport>().SendGet("/api/building/map_name/" + map_name, new BuildingResultJson(), (resultJson) =>
        {

            BuildingResultJson result = (BuildingResultJson)resultJson;
            building_num = result.data.Count;

            foreach(BuildingJson b in result.data){
                GameObject prefab = Resources.Load("prefab/" + b.prefab_name) as GameObject;
                GameObject buildingInstance = Instantiate(prefab) as GameObject;
                buildingInstance.transform.SetParent(canvasObject.transform);
                buildingInstance.transform.localPosition = new Vector3(float.Parse(b.pos.y), float.Parse(b.pos.x), float.Parse(b.pos.z));
                buildingInstance.transform.localScale = new Vector3(1, 1, 1);
                buildingInstance.GetComponent<BuildingBehaviourScript>().setBuildingInfo(b);
                buildingInstance.SetActive(true);
                buildingInstance.layer = 0;
            }

            charactorButton.transform.SetAsLastSibling();
            mapButton.transform.SetAsLastSibling();
        });

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
