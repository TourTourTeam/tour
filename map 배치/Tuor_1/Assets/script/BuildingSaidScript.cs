using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSaidScript : MonoBehaviour {
    public Text buyText;
    public Text parttimeText;

    /*  말풍선의 정보를 세팅 */
    public void setInfo(BuildingJson info){
        buyText.text = info.price.sale;
        parttimeText.text = info.part_time_job.money;
    }


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
