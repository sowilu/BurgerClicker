using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public BurgerManager burgerManager;
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI bpsText;
    
    void Update()
    {
        clicksText.text = burgerManager.burgers.ToString("F0");
        bpsText.text = burgerManager.burgersPerSecond.ToString("F0") + " bps";
    }
}
