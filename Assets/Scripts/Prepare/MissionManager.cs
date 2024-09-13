using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBase
{
    public int CampaignNumber;
    public int MissionNumber;
    public string Name;
}

public class MissionArmy
{
    public Army Army;
}

public class Mission
{
    public MissionBase MissionBase;
    public MissionArmy MissionArmy;

    public Mission(int campaignNumber, int missionNumber, string name, Army army) 
    {
        MissionBase = new MissionBase()
        {
            CampaignNumber = campaignNumber,
            MissionNumber = missionNumber,
            Name = name
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
        MissionList.AllMission.Add(new Mission(1,1,"",new Army()));
    }
}
