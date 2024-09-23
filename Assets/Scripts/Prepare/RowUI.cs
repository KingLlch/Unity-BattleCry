using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowUI : MonoBehaviour
{
    public int IndexRow;

    public List<ColumnUI> Columns;

    public Button[] SpeedChange;

    public void SetSlowPace()
    {
        SetRowSpeed(SpeedRow.SlowPace);
    }

    public void SetPace()
    {
        SetRowSpeed(SpeedRow.Pace);
    }

    public void SetRun()
    {
        SetRowSpeed(SpeedRow.Run);
    }

    public void SetRowSpeed(SpeedRow SpeedRow)
    {
        if (SpeedRow == SpeedRow.SlowPace)
        {
            SpeedChange[2].gameObject.SetActive(false);
            SpeedChange[0].gameObject.SetActive(true);
        }
        else if (SpeedRow == SpeedRow.Pace)
        {
            SpeedChange[0].gameObject.SetActive(false);
            SpeedChange[1].gameObject.SetActive(true);
        }
        else if (SpeedRow == SpeedRow.Run)
        {
            SpeedChange[1].gameObject.SetActive(false);
            SpeedChange[2].gameObject.SetActive(true);
        }

        PrepareManager.Instance.Army.Rows[IndexRow].SpeedRow = SpeedRow;
    }
}
