using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public BurgerManager manager;
    public GameObject shopItemPrefab;
    public Transform shopContentParent;

    public List<Building> buildings;
    public List<Upgrade> upgrades;

    public RectTransform panel;
    public float slideSpeed = 600f;
    public bool isOpen = false;
    private Vector2 closedPos;
    private Vector2 openPos;

    void Start()
    {
        openPos = panel.anchoredPosition;
        closedPos = new Vector2(openPos.x + panel.rect.width, openPos.y);
        panel.anchoredPosition = closedPos;

        GenerateShop();
    }

    void GenerateShop()
    {
        foreach (Transform child in shopContentParent)
            Destroy(child.gameObject);

        foreach (var b in buildings)
        {
            GameObject entry = Instantiate(shopItemPrefab, shopContentParent);
            entry.GetComponent<ShopItemUI>().Initialize(b, null, manager);
        }

        foreach (var u in upgrades)
        {
            GameObject entry = Instantiate(shopItemPrefab, shopContentParent);
            entry.GetComponent<ShopItemUI>().Initialize(null, u, manager);
        }
    }

    public void ToggleShop()
    {
        isOpen = !isOpen;
        StopAllCoroutines();
        StartCoroutine(SlidePanel());
    }

    System.Collections.IEnumerator SlidePanel()
    {
        while (true)
        {
            Vector2 target = isOpen ? openPos : closedPos;
            panel.anchoredPosition = Vector2.MoveTowards(
                panel.anchoredPosition,
                target,
                slideSpeed * Time.deltaTime
            );

            if (Vector2.Distance(panel.anchoredPosition, target) < 0.01f)
                yield break;

            yield return null;
        }
    }
}
