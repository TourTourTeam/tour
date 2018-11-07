using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour {
    public List<GameObject> buildingList;
    public List<Vector2> buildingPos;

    public GameObject building1Prefab;
    public GameObject canvasObject;
    public GameObject transportManager;

    public int building_num = 4;

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
                buildingPos.Add(new Vector2(float.Parse(b.y),float.Parse(b.x)));
            }

            for (int i = 0; i < building_num; i++)
            {
                buildingList.Add(Instantiate(building1Prefab) as GameObject);
                buildingList[i].transform.SetParent(canvasObject.transform);
                buildingList[i].transform.position = buildingPos[i];
                buildingList[i].transform.localScale = new Vector3(1, 1, 1);
                buildingList[i].GetComponent<BuildingBehaviourScript>().setBuildingInfo(i + "0000");
                buildingList[i].SetActive(true);
            }
        });

        /*  나중에 network module을 이용해 위치정보를 가져와야함 */
        /*
        buildingPos.Add(new Vector2(200, 300));
        buildingPos.Add(new Vector2(400, 300));
        buildingPos.Add(new Vector2(200, 400));
        buildingPos.Add(new Vector2(400, 400));
        */

        /*
        for (int i = 0; i < BUILDING_NUM; i++)
        {
            buildingList.Add(Instantiate(building1Prefab) as GameObject);
            buildingList[i].transform.SetParent(canvasObject.transform);
            buildingList[i].transform.position = buildingPos[i];
            buildingList[i].transform.localScale = new Vector3(1, 1, 1);
            buildingList[i].GetComponent<BuildingBehaviourScript>().setBuildingInfo(i + "0000");
            buildingList[i].SetActive(true);
        }*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
