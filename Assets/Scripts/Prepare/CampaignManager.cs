using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignManager : MonoBehaviour
{
    private static CampaignManager _instance;

    public static CampaignManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CampaignManager>();
            }

            return _instance;
        }
    }

    public GameObject[] Campaign;
    public GameObject MissionPrefab;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        foreach(Mission mission in MissionList.AllMission)
        {
            MissionUI newMission = Instantiate(MissionPrefab, Vector2.zero,Quaternion.identity, Campaign[mission.MissionBase.CampaignNumber].transform).GetComponent<MissionUI>();
        }

    }

    public void StartMission()
    {

    }
}
