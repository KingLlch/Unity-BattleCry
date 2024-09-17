using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject[] CampaignParents;
    public GameObject MissionPrefab;

    public GameObject MissionInfoPanel;

    public TextMeshProUGUI MissionInfoPanelName;
    public TextMeshProUGUI MissionInfoPanelDescription;

    public Mission CurrentMission;

    public Mission PreviousMission;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        foreach (Mission mission in MissionList.AllMission)
        {
            MissionUI newMission = Instantiate(MissionPrefab, Vector2.zero, Quaternion.identity, CampaignParents[mission.MissionBase.CampaignNumber].transform).GetComponent<MissionUI>();
            newMission.ThisMission = mission;
            newMission.MissionName.text = mission.MissionBase.Name;
            newMission.MissionImage.sprite = mission.MissionBase.Sprite;
            newMission.GetComponent<RectTransform>().localPosition = Vector3.zero;

            if (PreviousMission!= null && !PreviousMission.MissionBase.Completed)
            {
                newMission.ButtonStartMission.interactable = false;
            }

            PreviousMission = mission;
        }

        foreach (GameObject campaignParent in CampaignParents)
        {
            int height = Mathf.CeilToInt((float)campaignParent.transform.childCount) * 400 + (Mathf.CeilToInt((float)campaignParent.transform.childCount) - 1) * 30 + 50;
            campaignParent.GetComponent<RectTransform>().sizeDelta = new Vector2(campaignParent.GetComponent<RectTransform>().sizeDelta.x, height);
        }
    }

    public void OpenStartMissionPanel(Mission mission)
    {
        MissionInfoPanel.SetActive(true);
        MissionInfoPanelName.text = mission.MissionBase.Name;
        MissionInfoPanelDescription.text = mission.MissionBase.Description;
        CurrentMission = mission;
    }

    public void StartMission()
    {

        SaveAndLoad.Instance.SaveAll();

        BattleInfo.Instance.PlayerArmy = PrepareManager.Instance.Army;
        BattleInfo.Instance.EnemyArmy = CurrentMission.MissionArmy.Army;

        BattleInfo.Instance.CampaignNumber = CurrentMission.MissionBase.CampaignNumber;
        BattleInfo.Instance.MissionNumber = CurrentMission.MissionBase.MissionNumber;

        BattleInfo.Instance.Gold = CurrentMission.MissionBase.Gold;
        SceneManager.LoadScene("Battle");
    }
}
