using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {
    GameObject said;
    GameObject transportManager;
    public int layer;

	// Use this for initialization
	void Start () {
        this.said = GameObject.Find("said");
        this.said.SetActive(false);

        this.transportManager = GameObject.Find("TransportManager");
        //this.transportManager.GetComponent<Transport>().PostButtonClick(1);
	}

    /*  말풍선을 보이게 함  */
    public void activateSaid(string info){
        this.said.GetComponent<SaidBehaviorScript>().setInfo(info);
        this.said.transform.position = new Vector2(500, 300);
        this.said.transform.localScale = new Vector3(150, 150, 1);
        this.said.SetActive(true);
    }

    /*  말풍선을 안보이게 함 */
    public void deactivateSaid(){
        this.said.SetActive(false);
    }


    // Update is called once per frame
    void Update () {
		
	}

}
