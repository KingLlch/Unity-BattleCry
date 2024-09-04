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

        Points.text = unit.unitCharacteristics.Points.ToString();

        Health.text = unit.unitCharacteristics.Health + " / " + unit.unitCharacteristics.MaxHealth;

        PierceDamage.text = unit.unitCharacteristics.Damages.PierceDamage.ToString();
        SlashDamage.text = unit.unitCharacteristics.Damages.SlashDamage.ToString();
        BluntDamage.text = unit.unitCharacteristics.Damages.BluntDamage.ToString();
        FireDamage.text = unit.unitCharacteristics.Damages.FireDamage.ToString();
        IceDamage.text = unit.unitCharacteristics.Damages.IceDamage.ToString();
        EarthDamage.text = unit.unitCharacteristics.Damages.EarthDamage.ToString();
        PoisonDamage.text = unit.unitCharacteristics.Damages.PoisonDamage.ToString();
        WaterDamage.text = unit.unitCharacteristics.Damages.WaterDamage.ToString();
        LightDamage.text = unit.unitCharacteristics.Damages.LightDamage.ToString();
        DarknessDamage.text = unit.unitCharacteristics.Damages.DarknessDamage.ToString();

        PierceResist.text = unit.unitCharacteristics.Resists.PierceResist.ToString();
        SlashResist.text = unit.unitCharacteristics.Resists.SlashResist.ToString();
        BluntResist.text = unit.unitCharacteristics.Resists.BluntResist.ToString();
        FireResist.text = unit.unitCharacteristics.Resists.FireResist.ToString();
        IceResist.text = unit.unitCharacteristics.Resists.IceResist.ToString();
        EarthResist.text = unit.unitCharacteristics.Resists.EarthResist.ToString();
        PoisonResist.text = unit.unitCharacteristics.Resists.PoisonResist.ToString();
        WaterResist.text = unit.unitCharacteristics.Resists.WaterResist.ToString();
        LightResist.text = unit.unitCharacteristics.Resists.LightResist.ToString();
        DarknessResist.text = unit.unitCharacteristics.Resists.DarknessResist.ToString();

        AttackTime.text = unit.unitCharacteristics.AttackTime.ToString();

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
