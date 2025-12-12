using System;
using UnityEngine;
using DG.Tweening;

public class BurgerClicker : MonoBehaviour
{
    public BurgerManager manager;

    [Header("Animation Settings")] 
    public float duration = 0.3f;
    public float scale = 1.3f;
    public Ease ease = Ease.OutBounce;

    [Header("Upgrades")] 
    public GameObject[] models;
    private int index = 0;
    
    [Header("Sound effects")]
    public AudioClip burgerSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BurgerManager.OnUniqueBuildingBought.AddListener(Upgrade);
    }

    void OnMouseDown()
    {
        audioSource.PlayOneShot(burgerSound);
        manager.ClickBurger();
        
        transform.DOKill();
        transform.DOScale(Vector3.one, duration)
            .ChangeStartValue(Vector3.one * scale)
            .SetEase(ease);
    }

    public void Upgrade()
    {
        if (index + 1 < models.Length)
        {
            models[index].SetActive(false);
            models[++index].SetActive(true);
        }
        
    }
}