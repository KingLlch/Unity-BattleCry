using UnityEngine;

public class BattleInfo : MonoBehaviour
{
    private static BattleInfo _instance;

    public Army PlayerArmy = new Army();
    public Army EnemyArmy = new Army();

    public int CampaignNumber;
    public int MissionNumber;

    public int Gold;

    public bool IsWin;

    public static BattleInfo Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
