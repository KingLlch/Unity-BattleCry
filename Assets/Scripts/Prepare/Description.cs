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
        if (PrepareUIManager.Instance.IsDrug)
            return;

        Points.text = unit.unit.Points.ToString();

        Health.text = unit.unit.Health + " / " + unit.unit.MaxHealth;

        PierceDamage.text = unit.unit.Damages.PierceDamage.ToString();
        SlashDamage.text = unit.unit.Damages.SlashDamage.ToString();
        BluntDamage.text = unit.unit.Damages.BluntDamage.ToString();
        FireDamage.text = unit.unit.Damages.FireDamage.ToString();
        IceDamage.text = unit.unit.Damages.IceDamage.ToString();
        EarthDamage.text = unit.unit.Damages.EarthDamage.ToString();
        PoisonDamage.text = unit.unit.Damages.PoisonDamage.ToString();
        WaterDamage.text = unit.unit.Damages.WaterDamage.ToString();
        LightDamage.text = unit.unit.Damages.LightDamage.ToString();
        DarknessDamage.text = unit.unit.Damages.DarknessDamage.ToString();

        PierceResist.text = unit.unit.Resists.PierceResist.ToString();
        SlashResist.text = unit.unit.Resists.SlashResist.ToString();
        BluntResist.text = unit.unit.Resists.BluntResist.ToString();
        FireResist.text = unit.unit.Resists.FireResist.ToString();
        IceResist.text = unit.unit.Resists.IceResist.ToString();
        EarthResist.text = unit.unit.Resists.EarthResist.ToString();
        PoisonResist.text = unit.unit.Resists.PoisonResist.ToString();
        WaterResist.text = unit.unit.Resists.WaterResist.ToString();
        LightResist.text = unit.unit.Resists.LightResist.ToString();
        DarknessResist.text = unit.unit.Resists.DarknessResist.ToString();

        AttackTime.text = unit.unit.AttackTime.ToString();

        DescriptionGameObject.transform.localPosition = position + new Vector3(170 - Screen.width / 2, 0 - Screen.height / 2, 0) ;
        DescriptionGameObject.SetActive(true);
    }

    public void ChangePositionDescription(Vector3 position)
    {
        DescriptionGameObject.transform.localPosition = position + new Vector3(170 - Screen.width / 2, 0 - Screen.height / 2, 0);
    }

    public void HideDescription()
    {
        DescriptionGameObject.SetActive(false);
    }
}
