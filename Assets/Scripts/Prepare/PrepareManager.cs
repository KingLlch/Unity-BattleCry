using UnityEngine;

public class PrepareManager : MonoBehaviour
{
    public Army Army = new Army();

    private static PrepareManager _instance;

    public static PrepareManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PrepareManager>();
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

    private void Start()
    {

    }

    public void AddUnitToArmy(Unit unit, CellUI cell)
    {
        Army.AddUnit(unit, cell);
    }

    public void DeleteUnit()
    {

    }
}

public enum ItemType
{
    Race = 0,
    Weapon = 1,
    Armor = 2,
    Shield = 3,
    Special = 4
}
