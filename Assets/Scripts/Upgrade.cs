using UnityEngine;
public enum UpgradeType
{
    ClickMultiplier,
    BuildingMultiplier,
    GlobalMultiplier
}

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Burger Clicker/Upgrade")]
public class Upgrade : ScriptableObject
{
    public Sprite icon;
    public string upgradeName;
    public UpgradeType upgradeType;
    public double value;
    public Building targetBuilding;
    public double cost;
    [HideInInspector] public bool purchased;
}
