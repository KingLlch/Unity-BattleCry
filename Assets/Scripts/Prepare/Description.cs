using TMPro;
using UnityEngine;
using System.Reflection;
using System;
using static UnityEditor.Progress;

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


    public TextMeshProUGUI Name;

    public TextMeshProUGUI Points;

    public TextMeshProUGUI Health;

    public TextMeshProUGUI[] Damages;
    public TextMeshProUGUI[] Resists;

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

    public void ShowDescriptionUnit(Unit unit, Vector3 position)
    {
        if (PrepareUIManager.Instance.IsDrug)
            return;

        Name.text = unit.unitCharacteristics.Name.ToString();

        Points.text = unit.unitCharacteristics.Points.ToString();

        Health.text = unit.unitCharacteristics.Health + " / " + unit.unitCharacteristics.MaxHealth;

        Damages damages = unit.unitCharacteristics.Damages;
        Type damageType = damages.GetType();
        FieldInfo[] damagefields = damageType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if((int)damagefields[i].GetValue(damages) != 0)
            {
                Damages[i].transform.parent.gameObject.SetActive(true);
                Damages[i].text = ((int)damagefields[i].GetValue(damages)).ToString();
            }
            else
                Damages[i].transform.parent.gameObject.SetActive(false);
        }

        Resists resists = unit.unitCharacteristics.Resists;
        Type resistType = resists.GetType();
        FieldInfo[] resistfields = resistType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if((int)resistfields[i].GetValue(resists) != 0)
            {
                Resists[i].transform.parent.gameObject.SetActive(true);
                Resists[i].text = ((int)resistfields[i].GetValue(resists)).ToString();
            }
            else
                Resists[i].transform.parent.gameObject.SetActive(false);
        }

        AttackTime.text = unit.unitCharacteristics.AttackTime.ToString();

        DescriptionGameObject.transform.localPosition = position + new Vector3(170 - Screen.width / 2, 0 - Screen.height / 2, 0) ;
        DescriptionGameObject.SetActive(true);
    }

    public void ShowDescriptionItem(Item item, Vector3 position)
    {
        Name.text = item.Base.Name.ToString();

        Points.text = item.Base.Points.ToString();

        Health.text = item.Base.Health.ToString();

        Damages damages = item.Damages;
        Type damageType = damages.GetType();
        FieldInfo[] damagefields = damageType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if ((int)damagefields[i].GetValue(damages) != 0)
            {
                Damages[i].transform.parent.gameObject.SetActive(true);
                Damages[i].text = ((int)damagefields[i].GetValue(damages)).ToString();
            }
            else
                Damages[i].transform.parent.gameObject.SetActive(false);
        }

        Resists resists = item.Resists;
        Type resistType = resists.GetType();
        FieldInfo[] resistfields = resistType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if ((int)resistfields[i].GetValue(resists) != 0)
            {
                Resists[i].transform.parent.gameObject.SetActive(true);
                Resists[i].text = ((int)resistfields[i].GetValue(resists)).ToString();
            }
            else
                Resists[i].transform.parent.gameObject.SetActive(false);
        }

        DescriptionGameObject.transform.localPosition = position + new Vector3(170 - Screen.width / 2, 0 - Screen.height / 2, 0);
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
