using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBase
{
    public int CampaignNumber;
    public int MissionNumber;
    public string Name;
    public string Description;
    public Sprite Sprite;
}

public class MissionArmy
{
    public Army Army;
}

public class Mission
{
    public MissionBase MissionBase;
    public MissionArmy MissionArmy;

    public Mission(int campaignNumber, int missionNumber, string name, string spritePath, Army army, string description = "") 
    {
        MissionBase = new MissionBase()
        {
            CampaignNumber = campaignNumber,
            MissionNumber = missionNumber,
            Name = name,
            Description = description,
            Sprite = Resources.Load<Sprite>(spritePath)
        };

        MissionArmy = new MissionArmy()
        {
            Army = army
        };
    }
}

public static class MissionList
{
    public static List<Mission> AllMission = new List<Mission>();
}


public class MissionManager : MonoBehaviour
{
    private void Awake()
    {
        AddMission();
    }

    private void AddMission()
    {
        MissionList.AllMission.Add(new Mission(0, 0, "Mission1", "Sprites/Missions/Mission1", new Army(), "MissionDesc"));
        MissionList.AllMission.Add(new Mission(0, 1, "Mission2", "Sprites/Missions/Mission1", new Army(), "MissionDesc"));
        MissionList.AllMission.Add(new Mission(0, 2, "Mission3", "Sprites/Missions/Mission1", new Army(), "MissionDesc"));
        MissionList.AllMission.Add(new Mission(0, 3, "Mission4", "Sprites/Missions/Mission1", new Army(), "MissionDesc"));
        MissionList.AllMission.Add(new Mission(0, 4, "Mission5", "Sprites/Missions/Mission1", new Army(), "MissionDesc"));
        MissionList.AllMission.Add(new Mission(0, 5, "Mission6", "Sprites/Missions/Mission1", new Army(), "MissionDesc"));
        MissionList.AllMission.Add(new Mission(0, 6, "Mission7", "Sprites/Missions/Mission1", new Army(), "MissionDesc"));
    }
}
