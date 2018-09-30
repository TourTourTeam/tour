using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building1Generator : MonoBehaviour {
    public List<GameObject> buildingList;
    public List<Vector2> buildingPos;

    public GameObject building1Prefab;

    public static int BUILDING_NUM = 4;

	// Use this for initialization
	void Start () {

        /*  나중에 network module을 이용해 위치정보를 가져와야함 */
        buildingPos.Add(new Vector2(-3, -2));
        buildingPos.Add(new Vector2(-3, 2));
        buildingPos.Add(new Vector2(3, -2));
        buildingPos.Add(new Vector2(3, 2));

        for (int i = 0; i < BUILDING_NUM; i++)
        {
            buildingList.Add(Instantiate(building1Prefab) as GameObject);
            buildingList[i].transform.position = buildingPos[i];
            buildingList[i].GetComponent<BuildingBehaviourScript>().setBuildingInfo(i);
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
