using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject SettingsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Prepare");
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
