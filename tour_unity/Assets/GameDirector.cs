using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {
    GameObject said;

	// Use this for initialization
	void Start () {
        this.said = GameObject.Find("said");
        this.said.SetActive(false);
	}

    public void activateSaid(int info){
        this.said.SetActive(true);
        this.said.GetComponent<SaidBehaviorScript>().setInfo(info);
    }

    public void deactivateSaid(){
        this.said.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
