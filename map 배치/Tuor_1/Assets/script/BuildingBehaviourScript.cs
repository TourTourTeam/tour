using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviourScript : MonoBehaviour {
    public GameObject gameDirector;
    public GameObject dataManager;
    BuildingJson info;

    /*  빌딩의 정보를 set하는 부분. 
        나중에 따로 building info class를 setting 할 예정*/
    public void setBuildingInfo(BuildingJson bi){
        this.info = bi;

        this.dataManager = GameObject.Find("DataManager");
    }

	// Use this for initialization
	void Start () {
        this.gameDirector = GameObject.Find("GameDirector");  
	}


    /*
     * building이 눌러졌을 때 말풍선이 뜰 수 있도록 gameDirector에게 부탁한당
    */
    public void  Onclick(){
        UserJson user = (UserJson)dataManager.GetComponent<StaticDataManager>().dataMap["user"];

        if (user.id.Equals(info.owner_id))
        {
            gameDirector.GetComponent<GameDirector>().activateBuildingOnwerSaid(this.info);
        }else{
            gameDirector.GetComponent<GameDirector>().activateBuildingSaid(this.info);
        }
    }

	// Update is called once per frame
	void Update () {

	}
}
