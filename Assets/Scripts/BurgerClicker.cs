using UnityEngine;

// Handles clicking on the burger patty itself
public class BurgerClicker : MonoBehaviour
{
    public BurgerManager manager;

    void OnMouseDown()
    {
        manager.ClickBurger();
    }
}