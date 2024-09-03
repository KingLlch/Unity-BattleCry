using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareManager : MonoBehaviour
{
    private PrepareManager instance;

    public PrepareManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this;
        }
    }
}
