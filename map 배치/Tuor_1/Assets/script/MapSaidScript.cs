using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSaidScript : MonoBehaviour {
    public Text testText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setUpText(string newText){
        this.testText.text = newText;
    }
}
