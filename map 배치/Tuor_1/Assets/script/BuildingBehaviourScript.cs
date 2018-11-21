using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviourScript : MonoBehaviour {
    public GameObject gameDirector;
    BuildingJson info;

    /*  빌딩의 정보를 set하는 부분. 
        나중에 따로 building info class를 setting 할 예정*/
    public void setBuildingInfo(BuildingJson bi){
        this.info = bi;
        Debug.Log("setting building info : " + bi);
    }

	// Use this for initialization
	void Start () {
        this.gameDirector = GameObject.Find("GameDirector");  
	}


    /*
     * building이 눌러졌을 때 말풍선이 뜰 수 있도록 gameDirector에게 부탁한당
    */
    public void  Onclick(){
        gameDirector.GetComponent<GameDirector>().activateBuildingSaid(this.info);
    }

	// Update is called once per frame
	void Update () {

	}
}
