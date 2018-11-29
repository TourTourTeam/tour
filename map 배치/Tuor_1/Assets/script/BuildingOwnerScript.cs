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
        saleText.text = info.price.sale;
        parttimeText.text = info.part_time_job.number;
        areaText.text = info.area;

        double income = double.Parse(info.part_time_job.number) * double.Parse(info.part_time_job.money);
        incomeText.text = income.ToString();
    }
}
