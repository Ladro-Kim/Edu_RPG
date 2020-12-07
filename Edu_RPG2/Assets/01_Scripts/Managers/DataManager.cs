using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class StatData
{
    public List<Stats> stats = new List<Stats>();
}

public class DataManager
{
    public void Init()
    {
        TextAsset textAsset = Managers._resource.Load<TextAsset>($"Data/StatData");
        StatData data = JsonUtility.FromJson<StatData>(textAsset.text);
    }

    public DataManager()
    {

    }
}
