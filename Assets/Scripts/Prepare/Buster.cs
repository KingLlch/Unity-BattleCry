using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class Buster : MonoBehaviour
{
    public int CommonItemCount;
    public int UncommonItemCount;
    public int RareItemCount;
    public int EpicItemCount;
    public int LegendaryItemCount;
    public int MythicalItemCount;

    public BusterItems BusterItems = new BusterItems();

    public Image ImageBuster;
    public Button BuyButton;
    public TextMeshProUGUI ItemsText;
    public TextMeshProUGUI CostText;

    public int Cost;

    private void Awake()
    {
        CostText.text = Cost.ToString();

        BusterItems.CommonItemCount = CommonItemCount;
        BusterItems.UncommonItemCount = UncommonItemCount;
        BusterItems.RareItemCount = RareItemCount;
        BusterItems.EpicItemCount = EpicItemCount;
        BusterItems.LegendaryItemCount = LegendaryItemCount;
        BusterItems.MythicalItemCount = MythicalItemCount;

        ItemsText.text =  BusterItems.CommonItemCount + " Common" +
            "\n" + BusterItems.UncommonItemCount + " Uncommon" +
            "\n" + BusterItems.RareItemCount + " Rare" +
            "\n" + BusterItems.EpicItemCount + " Epic" +
            "\n" + BusterItems.LegendaryItemCount + " Legendary" +
            "\n" + BusterItems.MythicalItemCount + " Mythical";
    }

    public void BuyBooster()
    {
        ShopManager.Instance.BuyBooster(BusterItems, Cost);
    }
}
