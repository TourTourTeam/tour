using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingOwnerScript : MonoBehaviour {
    public Text saleText;
    public Text parttimeText;
    public Text areaText;
    public Text incomeText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setInfo(BuildingJson info){
        saleText.text = info.money;
        parttimeText.text = info.money;
        areaText.text = info.money;
        incomeText.text = info.money;
    }
}
