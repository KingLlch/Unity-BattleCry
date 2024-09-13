using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfo : MonoBehaviour
{
    private static BattleInfo _instance;

    public Army PlayerArmy;
    public Army EnemyArmy;

    public int CampaignNumber;
    public int MissionNumber;

    public int Gold;

    public bool IsWin;

    public static BattleInfo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BattleInfo>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
