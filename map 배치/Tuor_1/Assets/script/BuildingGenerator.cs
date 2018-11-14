using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour {
    public List<GameObject> buildingList;
    public List<Vector2> buildingPos;

    public GameObject[] buildingsPrefab = new GameObject[15];

    public GameObject canvasObject;
    public GameObject transportManager;

    public int building_num;

	// Use this for initialization
	void Start () {
        canvasObject = GameObject.Find("Canvas");
        transportManager = GameObject.Find("TransportManager");

        BuildingListJson buildingListJson = new BuildingListJson();
        transportManager.GetComponent<Transport>().SendGet("/buildings", buildingListJson, (resultJson) =>
        {
            BuildingListJson result = (BuildingListJson)resultJson;
            building_num = int.Parse(result.length);
            foreach(BuildingJson b in result.data){
                buildingPos.Add(new Vector3(float.Parse(b.y),float.Parse(b.x)));
            }

            for (int i = 0; i < building_num; i++)
            {
                buildingList.Add(Instantiate(buildingsPrefab[i]) as GameObject);
                buildingList[i].transform.SetParent(canvasObject.transform);
                buildingList[i].transform.localPosition = buildingPos[i];//수정
                buildingList[i].transform.localScale = new Vector3(1, 1, 1);
                buildingList[i].GetComponent<BuildingBehaviourScript>().setBuildingInfo(i + "0000");
                buildingList[i].SetActive(true);
                buildingList[i].layer = '2';
            }
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
