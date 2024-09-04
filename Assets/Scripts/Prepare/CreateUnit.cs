using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{

    private static CreateUnit _instance;

    public static CreateUnit Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CreateUnit>();
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
    }

    public void CreateNewUnit()
    {

        CloseCreateUnitPanel();
    }

    public void CloseCreateUnitPanel()
    {
        ClearCreateUnit();
        gameObject.SetActive(false);
    }

    public void ClearCreateUnit()
    {

    }

    public void LoadUnit()
    {

    }
}
