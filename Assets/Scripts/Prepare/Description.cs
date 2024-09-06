using System;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
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

    public TextMeshProUGUI Name;
    public TextMeshProUGUI ItemName;

    public TextMeshProUGUI Points;

    public TextMeshProUGUI Health;

    public GameObject[] DamagesGameObjects;
    public TextMeshProUGUI[] Damages;

    public GameObject[] ResistsGameObjects;
    public TextMeshProUGUI[] Resists;

    public TextMeshProUGUI AttackInterval;
    public TextMeshProUGUI AttackRange;

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
        ItemName.text = unit.unitCharacteristics.RaceName + "\n" + unit.unitCharacteristics.WeaponName + "\n" + unit.unitCharacteristics.ArmorName + "\n" + unit.unitCharacteristics.ShieldName + "\n" + unit.unitCharacteristics.SpecialName;
        Points.text = unit.unitCharacteristics.Points.ToString();
        Health.text = unit.unitCharacteristics.Health + " / " + unit.unitCharacteristics.MaxHealth;

        Damages damages = unit.unitCharacteristics.Damages;
        Type damageType = damages.GetType();
        FieldInfo[] damagefields = damageType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if ((int)damagefields[i].GetValue(damages) != 0)
            {
                DamagesGameObjects[i].SetActive(true);
                Damages[i].gameObject.SetActive(true);
                Damages[i].text = ((int)damagefields[i].GetValue(damages)).ToString();
            }
            else
            {
                Damages[i].gameObject.SetActive(false);
                DamagesGameObjects[i].SetActive(false);
            }
        }

        Resists resists = unit.unitCharacteristics.Resists;
        Type resistType = resists.GetType();
        FieldInfo[] resistfields = resistType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if ((int)resistfields[i].GetValue(resists) != 0)
            {
                ResistsGameObjects[i].SetActive(true);
                Resists[i].gameObject.SetActive(true);
                Resists[i].text = ((int)resistfields[i].GetValue(resists)).ToString();
            }
            else
            {
                Resists[i].gameObject.SetActive(false);
                ResistsGameObjects[i].SetActive(false);
            }
        }

        AttackInterval.text = unit.unitCharacteristics.AttackTime.ToString();
        AttackRange.text = unit.unitCharacteristics.AttackRange.ToString();

        DescriptionGameObject.transform.localPosition = position + new Vector3(170 - Screen.width / 2, 0 - Screen.height / 2, 0);
        DescriptionGameObject.SetActive(true);
    }

    public void ShowDescriptionItem(Item item, Vector3 position)
    {
        if (item == null)
            return;

        Name.text = item.Base.Name.ToString();
        ItemName.text = item.Base.Description.ToString();
        Points.text = item.Base.Points.ToString();
        Health.text = item.Base.Health.ToString();

        Damages damages = item.Damages;
        Type damageType = damages.GetType();
        FieldInfo[] damagefields = damageType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if ((int)damagefields[i].GetValue(damages) != 0)
            {
                DamagesGameObjects[i].SetActive(true);
                Damages[i].gameObject.SetActive(true);
                Damages[i].text = ((int)damagefields[i].GetValue(damages)).ToString();
            }
            else
            {
                Damages[i].gameObject.SetActive(false);
                DamagesGameObjects[i].SetActive(false);
            }
        }

        Resists resists = item.Resists;
        Type resistType = resists.GetType();
        FieldInfo[] resistfields = resistType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if ((int)resistfields[i].GetValue(resists) != 0)
            {
                ResistsGameObjects[i].SetActive(true);
                Resists[i].gameObject.SetActive(true);
                Resists[i].text = ((int)resistfields[i].GetValue(resists)).ToString();
            }
            else
            {
                Resists[i].gameObject.SetActive(false);
                ResistsGameObjects[i].SetActive(false);
            }
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
