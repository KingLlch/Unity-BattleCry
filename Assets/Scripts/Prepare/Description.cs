using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public Image MainUnitImage;
    public Image RaceUnitImage;
    public Image WeaponUnitImage;
    public Image ArmorUnitImage;
    public Image ShieldUnitImage;
    public Image SpecialUnitImage;

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

    private int distanceX = 220;
    private int distanceY = -150;

    private float descriptionSizeX;
    private float descriptionSizeY;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        descriptionSizeX = gameObject.GetComponent<RectTransform>().rect.width;
        descriptionSizeY = gameObject.GetComponent<RectTransform>().rect.height;
    }

    public void ShowDescriptionUnit(UnitUI unit, Vector3 position)
    {
        if (FindAnyObjectByType<PrepareUIManager>() != null && PrepareUIManager.Instance.IsDrug)
            return;

        ChangeImageDescription(unit);

        Name.text = unit.Unit.Name.ToString();
        ItemName.text = unit.Unit.RaceName + "\n" + unit.Unit.WeaponName + "\n" + unit.Unit.ArmorName + "\n" + unit.Unit.ShieldName + "\n" + unit.Unit.SpecialName;
        Points.text = unit.Unit.Points.ToString();
        Health.text = unit.Unit.Health + " / " + unit.Unit.MaxHealth;

        Damages damages = unit.Unit.Damages;
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

        Resists resists = unit.Unit.Resists;
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

        AttackInterval.text = unit.Unit.AttackTime.ToString();
        AttackRange.text = unit.Unit.AttackRange.ToString();

        DescriptionGameObject.transform.localPosition = position + new Vector3(170 - Screen.width / 2, 0 - Screen.height / 2, 0);
        DescriptionGameObject.SetActive(true);
    }

    private void ChangeImageDescription(UnitUI unit)
    {
        MainUnitImage.sprite = unit.Unit.MainSprite;
        RaceUnitImage.gameObject.SetActive(true);
        RaceUnitImage.sprite = unit.Unit.RaceSprite;

        if (unit.Unit.Weapon != null)
        {
            WeaponUnitImage.gameObject.SetActive(true);
            WeaponUnitImage.sprite = unit.Unit.WeaponSprite;
        }
        else
            WeaponUnitImage.gameObject.SetActive(false);

        if (unit.Unit.Armor != null)
        {
            ArmorUnitImage.gameObject.SetActive(true);
            ArmorUnitImage.sprite = unit.Unit.ArmorSprite;
        }
        else
            ArmorUnitImage.gameObject.SetActive(false);

        if (unit.Unit.Shield != null)
        {
            ShieldUnitImage.gameObject.SetActive(true);
            ShieldUnitImage.sprite = unit.Unit.ShieldSprite;
        }
        else
            ShieldUnitImage.gameObject.SetActive(false);

        if (unit.Unit.Special != null)
        {
            SpecialUnitImage.gameObject.SetActive(true);
            SpecialUnitImage.sprite = unit.Unit.SpecialSprite;
        }
        else
            SpecialUnitImage.gameObject.SetActive(false);
    }

    public void ShowDescriptionItem(Item item, Vector3 position)
    {
        if (item == null)
            return;

        MainUnitImage.sprite = item.Base.ItemUISprite;
        RaceUnitImage.gameObject.SetActive(false);
        WeaponUnitImage.gameObject.SetActive(false);
        ArmorUnitImage.gameObject.SetActive(false);
        ShieldUnitImage.gameObject.SetActive(false);
        SpecialUnitImage.gameObject.SetActive(false);

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
        if ((position.x + descriptionSizeX + 50 < Screen.width) && (position.y - descriptionSizeY > 0))
        {
            DescriptionGameObject.transform.localPosition = position + new Vector3(distanceX, distanceY, 0) + new Vector3(-Screen.width / 2, -Screen.height / 2, 0);
        }
        else
        {
            if ((position.x + descriptionSizeX + 50 > Screen.width) && (position.y - descriptionSizeY < 0))
                DescriptionGameObject.transform.localPosition = position + new Vector3(-descriptionSizeX + 100, descriptionSizeY - position.y + distanceY, 0) + new Vector3(-Screen.width / 2, -Screen.height / 2, 0);
            else if (position.x + descriptionSizeX + 50 > Screen.width)
                DescriptionGameObject.transform.localPosition = position + new Vector3(-descriptionSizeX + 100, distanceY, 0) + new Vector3(-Screen.width / 2, -Screen.height / 2, 0);
            else
                DescriptionGameObject.transform.localPosition = position + new Vector3(distanceX, descriptionSizeY - position.y + distanceY, 0) + new Vector3(-Screen.width / 2, -Screen.height / 2, 0);
        }
    }

    public void HideDescription()
    {
        DescriptionGameObject.SetActive(false);
    }
}
