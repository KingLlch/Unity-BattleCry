using TMPro;
using UnityEngine;

public class Description : MonoBehaviour
{
    private static Description _instance;

    public static Description Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Description>();
            }

            return _instance;
        }
    }

    public GameObject DescriptionGameObject;

    public TextMeshProUGUI Points;

    public TextMeshProUGUI Health;

    public TextMeshProUGUI PierceDamage;
    public TextMeshProUGUI SlashDamage;
    public TextMeshProUGUI BluntDamage;
    public TextMeshProUGUI FireDamage;
    public TextMeshProUGUI IceDamage;
    public TextMeshProUGUI EarthDamage;
    public TextMeshProUGUI PoisonDamage;
    public TextMeshProUGUI WaterDamage;
    public TextMeshProUGUI LightDamage;
    public TextMeshProUGUI DarknessDamage;

    public TextMeshProUGUI PierceResist;
    public TextMeshProUGUI SlashResist;
    public TextMeshProUGUI BluntResist;
    public TextMeshProUGUI FireResist;
    public TextMeshProUGUI IceResist;
    public TextMeshProUGUI EarthResist;
    public TextMeshProUGUI PoisonResist;
    public TextMeshProUGUI WaterResist;
    public TextMeshProUGUI LightResist;
    public TextMeshProUGUI DarknessResist;

    public TextMeshProUGUI AttackTime;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void ShowDescription(Unit unit, Vector3 position)
    {
        Points.text = unit.unit.Points.ToString();

        Health.text = unit.unit.Health + " / " + unit.unit.MaxHealth;

        PierceDamage.text = unit.unit.PierceDamage.ToString();
        SlashDamage.text = unit.unit.SlashDamage.ToString();
        BluntDamage.text = unit.unit.BluntDamage.ToString();
        FireDamage.text = unit.unit.FireDamage.ToString();
        IceDamage.text = unit.unit.IceDamage.ToString();
        EarthDamage.text = unit.unit.EarthDamage.ToString();
        PoisonDamage.text = unit.unit.PoisonDamage.ToString();
        WaterDamage.text = unit.unit.WaterDamage.ToString();
        LightDamage.text = unit.unit.LightDamage.ToString();
        DarknessDamage.text = unit.unit.DarknessDamage.ToString();

        PierceResist.text = unit.unit.PierceResist.ToString();
        SlashResist.text = unit.unit.SlashResist.ToString();
        BluntResist.text = unit.unit.BluntResist.ToString();
        FireResist.text = unit.unit.FireResist.ToString();
        IceResist.text = unit.unit.IceResist.ToString();
        EarthResist.text = unit.unit.EarthResist.ToString();
        PoisonResist.text = unit.unit.PoisonResist.ToString();
        WaterResist.text = unit.unit.WaterResist.ToString();
        LightResist.text = unit.unit.LightResist.ToString();
        DarknessResist.text = unit.unit.DarknessResist.ToString();

        AttackTime.text = unit.unit.AttackTime.ToString();

        DescriptionGameObject.transform.position = position + new Vector3(120, 0, 0);
        DescriptionGameObject.SetActive(true);
    }

    public void ChangePositionDescription(Vector3 position)
    {
        DescriptionGameObject.transform.position = position + new Vector3(120, 0,0);
    }

    public void HideDescription()
    {
        DescriptionGameObject.SetActive(false);
    }
}
