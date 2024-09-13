using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    public Mission ThisMission;

    public Image MissionImage;
    public TextMeshProUGUI MissionName;


    public void StartMission()
    {
        CampaignManager.Instance.OpenStartMissionPanel(ThisMission);
    }
}
