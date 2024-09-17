using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    public Mission ThisMission;

    public Image MissionImage;
    public TextMeshProUGUI MissionName;

    public Button ButtonStartMission;


    public void StartMission()
    {
        CampaignManager.Instance.OpenStartMissionPanel(ThisMission);
    }
}
