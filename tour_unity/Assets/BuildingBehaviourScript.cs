using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviourScript : MonoBehaviour {
    public GameObject gameDirector;
    int buildingNum;

    public void setBuildingInfo(int bn){
        this.buildingNum = bn;
        Debug.Log("setting " + bn);
    }

	// Use this for initialization
	void Start () {
        this.gameDirector = GameObject.Find("GameDirector");  
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonUp(0)){
            gameDirector.GetComponent<GameDirector>().activateSaid(this.buildingNum);

        }
	}
}
