using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIManager : MonoBehaviour
{
    private static BattleUIManager _instance;

    public static BattleUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BattleUIManager>();
            }

            return _instance;
        }
    }

    public TextMeshProUGUI TimeText;
    public int TimeSpeed = 1;

    public GameObject EndBattlePanel;
    public TextMeshProUGUI EndBattlePanelHeader;
    public TextMeshProUGUI EndBattlePanelDescription;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        StartTimer();
    }

    public void EndBattle(bool isWin)
    {
        EndBattlePanel.SetActive(true);

        if (isWin)
        {
            EndBattlePanelHeader.text = "Win";
            EndBattlePanelDescription.text = "Ёту победу будут помнить веками командир!";
        }
        else
        {
            EndBattlePanelHeader.text = "Lose";
            EndBattlePanelDescription.text = "¬раг оказалс€ сильнее. Ќам нужно перегруппироватьс€ и попробоват снова!";
        }
    }

    public void LoadScenePrepare()
    {
        SceneManager.LoadScene("Prepare");
    }

    public void x4Speed()
    {
        Time.timeScale = 4f;
        TimeSpeed = 4;
    }

    public void x2Speed()
    {
        Time.timeScale = 2f;
        TimeSpeed = 2;
    }

    public void x1Speed()
    {
        Time.timeScale = 1f;
        TimeSpeed = 1;
    }

    public void Resume()
    {
        Time.timeScale = TimeSpeed;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Consede()
    {
        BattleInfo.Instance.IsWin = false;
        SceneManager.LoadScene("Prepare");
    }

    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        int timeSeconds = 0;
        int timeMinuts = 0;

        while (true)
        {
            timeSeconds++;

            if (timeSeconds >= 60)
            {
                timeSeconds = 0;
                timeMinuts++;
            }

            ChangeTimerUI(timeSeconds, timeMinuts);
            yield return new WaitForSeconds(1f);

        }
    }

    private void ChangeTimerUI(int seconds, int minuts)
    {
        if ((seconds < 10) && (minuts < 10)) TimeText.text = "0" + minuts + ":0" + seconds;
        else if (minuts < 10) TimeText.text = "0" + minuts + ":" + seconds;
        else if (seconds < 10) TimeText.text = minuts + ":0" + seconds;
        else TimeText.text = minuts + ":" + seconds;
    }
}
