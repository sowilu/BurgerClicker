using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "Burger Clicker/Building")]
public class Building : ScriptableObject
{
    public Sprite icon;
    public string buildingName;
    public double baseCost;
    public double baseProduction;
    [HideInInspector] public int ownedAmount;
}