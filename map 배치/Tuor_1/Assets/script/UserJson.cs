using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UserResultJson{
    public string success;
    public UserJson data;
}


[System.Serializable]
public class UserJson {
    public string id;
    public string name;
    public string salt;
    public string hashed_password;
    public string cur_map_name;
    public StatusJson status;
    public string character_shape_name;
    public string money;
    public string created_at;
    public string updated_at;
}

[System.Serializable]
public class StatusJson{
    public string fatigue;
    public string satiety;
    public string experience_point;
    public string level;
}