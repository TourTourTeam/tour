using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSaid : MonoBehaviour {
    public Slider bar1;
    public Slider bar2;
    public Slider bar3;
    public GameObject dataManager;
    public GameObject gameDirector;
    int updateCount;

	// Use this for initialization
	void Start () {
        this.dataManager = GameObject.Find("DataManager");
        this.gameDirector = GameObject.Find("GameDirector");

        UserJson user = (UserJson)this.dataManager.GetComponent<StaticDataManager>().dataMap["user"];
        bar1.value = float.Parse(user.status.fatigue);
        bar2.value = float.Parse(user.status.satiety);
        bar3.value = float.Parse(user.status.experience_point);

        updateCount = 1;


        /*
        test
        */

     }


	
	// Update is called once per frame
	void Update () {
        if (updateCount == 10)
        {
            bar1.value -= Time.deltaTime / 100;
            bar2.value -= Time.deltaTime / 100;
            updateCount = 0;

            /*
            새로운 값을 서버에 보내야.
            */


        }

        updateCount++;
    }



}
