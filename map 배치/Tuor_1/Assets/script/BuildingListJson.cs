using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BuildingListJson
{
    public string length;
    public List<BuildingJson> data;
}


[System.Serializable]
public class BuildingJson
{
    public string prefabName;
    public string x;
    public string y;
    public string money;
}