using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaidBehaviorScript : MonoBehaviour {
    public Text moneyText;

    /*  말풍선의 정보를 세팅 */
    public void setInfo(string info){
        moneyText.text = info;
    }


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
