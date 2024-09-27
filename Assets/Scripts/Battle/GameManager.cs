using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public Army PlayerArmy;
    public Army EnemyArmy;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        PlayerArmy = BattleInfo.Instance.PlayerArmy;
        EnemyArmy = BattleInfo.Instance.EnemyArmy;

        BattleField.Instance.LoadArmy(PlayerArmy, true);
        BattleField.Instance.LoadArmy(EnemyArmy, false);
    }

    public void StartBattle()
    {
        BattleUIManager.Instance.StartTimer();

    }

    public void Lose()
    {
        BattleInfo.Instance.IsWin = false;
        BattleUIManager.Instance.EndBattle(false);
    }

    public void Win()
    {
        BattleInfo.Instance.IsWin = true;
        BattleUIManager.Instance.EndBattle(true);
    }
}
