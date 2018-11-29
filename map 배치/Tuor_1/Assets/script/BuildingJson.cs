using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BuildingResultJson
{
    public string success;
    public List<BuildingJson> data;
}

[System.Serializable]
public class BuildingJson
{
    public string id;
    public string owner_id;
    public PosJson pos;
    public PriceJson price;
    public string area;
    public PartItmeJobJson part_time_job;
    public string prefab_name;
    public string map_name;
}

[System.Serializable]
public class PosJson
{
    public string x;
    public string y;
    public string z;
}

[System.Serializable]
public class PriceJson{
    public string cur;
    public string sale;
}

[System.Serializable]
public class PartItmeJobJson{
    public string number;
    public string money;
}