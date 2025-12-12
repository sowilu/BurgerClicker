using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemUI : MonoBehaviour
{
    [Header("UI")]
    public Image iconImage;
    public TMP_Text titleText;
    public TMP_Text priceText;
    public TMP_Text amountText;
    public Button buyButton;

    [Header("Data")]
    public Building buildingData;
    public Upgrade upgradeData;
    public BurgerManager manager;

    public void Initialize(Building building, Upgrade upgrade, BurgerManager mgr)
    {
        manager = mgr;
        buildingData = building;
        upgradeData = upgrade;

        if (buildingData != null)
        {
            iconImage.sprite = buildingData.icon;
            titleText.text = buildingData.buildingName;

            double scaledCost = buildingData.baseCost * Mathf.Pow(1.15f, buildingData.ownedAmount);
            priceText.text = scaledCost.ToString("F0") + " Burgers";
            amountText.text = "Owned: " + buildingData.ownedAmount;
        }

        if (upgradeData != null)
        {
            iconImage.sprite = upgradeData.icon;
            titleText.text = upgradeData.upgradeName;
            priceText.text = upgradeData.cost.ToString("F0") + " Burgers";

            if (upgradeData.purchased)
            {
                amountText.text = "Purchased";
                buyButton.gameObject.SetActive(false);
            }
            else
            {
                amountText.text = "";
                buyButton.gameObject.SetActive(true);
            }
        }

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(OnBuyPressed);
    }

    public void OnBuyPressed()
    {
        if (buildingData != null)
        {
            manager.BuyBuilding(buildingData);
            Initialize(buildingData, null, manager); 
        }

        if (upgradeData != null && upgradeData.purchased == false)
        {
            manager.BuyUpgrade(upgradeData);
            Initialize(null, upgradeData, manager); 
        }
    }
}
