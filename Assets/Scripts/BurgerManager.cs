using UnityEngine;
using System.Collections.Generic;

public class BurgerManager : MonoBehaviour
{
    public double burgers;
    public double burgersPerClick = 1;
    public List<Building> allBuildings;
    public List<Upgrade> allUpgrades;
    public double burgersPerSecond;

    void Update()
    {
        burgers += burgersPerSecond * Time.deltaTime;
    }

    public void ClickBurger()
    {
        burgers += burgersPerClick;
    }

    public void BuyBuilding(Building building)
    {
        double scaledCost = building.baseCost * Mathf.Pow(1.15f, building.ownedAmount);

        if (burgers >= scaledCost)
        {
            burgers -= scaledCost;
            building.ownedAmount++;
            allBuildings.Add(building);
            RecalculateBPS();
        }
    }

    public void BuyUpgrade(Upgrade upgrade)
    {
        if (upgrade.purchased == false && burgers >= upgrade.cost)
        {
            burgers -= upgrade.cost;
            upgrade.purchased = true;
            allUpgrades.Add(upgrade);

            if (upgrade.upgradeType == UpgradeType.ClickMultiplier)
            {
                burgersPerClick *= upgrade.value;
            }

            if (upgrade.upgradeType == UpgradeType.BuildingMultiplier && upgrade.targetBuilding != null)
            {
                upgrade.targetBuilding.baseProduction *= upgrade.value;
            }

            if (upgrade.upgradeType == UpgradeType.GlobalMultiplier)
            {
                burgersPerSecond *= upgrade.value;
            }

            RecalculateBPS();
        }
    }

    public void RecalculateBPS()
    {
        double total = 0;

        foreach (var b in allBuildings)
        {
            double scaledProduction = b.baseProduction * b.ownedAmount;
            total += scaledProduction;
        }

        burgersPerSecond = total;
    }
}