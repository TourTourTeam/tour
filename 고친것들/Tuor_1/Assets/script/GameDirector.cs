using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {
    GameObject building;
    GameObject said;
    GameObject transportManager;
    GameObject mapSaid;
    public int layer;

	// Use this for initialization
	void Start () {
        this.said = GameObject.Find("said");
        this.said.SetActive(false);
        this.transportManager = GameObject.Find("TransportManager");
        this.mapSaid = GameObject.Find("mapSaid");
    }

    /*  말풍선을 보이게 함  */
    public void activateSaid(string info){
        this.said.GetComponent<SaidBehaviorScript>().setInfo(info);
        this.said.transform.SetAsLastSibling();
        this.said.transform.localPosition = new Vector3(0, -166,0);
        this.said.transform.localScale = new Vector3(56, 50, 1);
        this.said.SetActive(true);
    }

    /*  말풍선을 안보이게 함 */
    public void deactivateSaid(){
        this.said.SetActive(false);
    }


    public void mapSearch(){
        MapListJson emptyJson = new MapListJson();
        transportManager.GetComponent<Transport>().SendGet("/maps", emptyJson, (resultJson) =>
        {
            MapListJson result = (MapListJson)resultJson;
            string testText = "";
            foreach(MapJson s in result.data){
                testText += s.name + " , ";
            }
            Debug.Log(testText.ToString());
            this.mapSaid.GetComponent<MapSaidScript>().setUpText(testText);
        });
    }


    // Update is called once per frame
    void Update () {
		
	}
}
