using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class MapListJson
{
    public string length;
    public List<MapJson> data;
}


[System.Serializable]
public class MapJson
{
    public string map_id;
    public string name;
}