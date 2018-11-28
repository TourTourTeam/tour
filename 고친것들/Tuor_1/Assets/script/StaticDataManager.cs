using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  DataManager는 게임을 계속하면서 데이터를 저장하고 있는 친구  */
public class StaticDataManager : MonoBehaviour {
    public ArrayList dataList;

	// Use this for initialization
	void Start () {
        dataList = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
