using System;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    public BurgerManager burgerManager;
    
    [Header("Particles")]
    public int maxParticles = 100;
    public float particleUpdateRate = 3;
    public List<ParticleSystem> particles;

    [Header("Bots")] 
    public Transform botParent;
    public List<GameObject> bots;
    public GameObject botPrefab;
    public int maxBots = 10;
    public float radius = 0.5f;
    private int botIndex = 0;
    
    private bool hasCows = false;
    private bool hasTomatos = false;

    void Start()
    {
        var angle = 360f / maxBots;
        for (float i = 0; i < 360; i+= angle)
        {
            var x = Mathf.Cos(i * Mathf.Deg2Rad) * radius;
            var y = Mathf.Sin(i * Mathf.Deg2Rad) * radius;
            
            var b = Instantiate(botPrefab, new Vector3(x, y, 0), Quaternion.identity, botParent);
            b.transform.LookAt(botParent);
            b.SetActive(false);
            bots.Add(b);
        }
        InvokeRepeating(nameof(UpdateParticles), 0, particleUpdateRate);
        BurgerManager.OnBuildingBought.AddListener(TurnOnEffects);
    }

    void UpdateParticles()
    {
        foreach (var p in particles)
        {
            var emission = p.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(
                Mathf.Min((int)Math.Ceiling(burgerManager.burgersPerSecond / 5), maxParticles)
            );
        }
    }

    void TurnOnEffects(Building building)
    {
        if (!hasCows && building.name.Contains("Cow"))
        {
            hasCows = true;
            particles[1].Play();
        }
        else if (!hasTomatos && building.name.Contains("Tomato"))
        {
            hasTomatos = true;
            particles[2].Play();
        }
        else if (building.name.Contains("Bots") && botIndex < bots.Count - 1)
        {
            bots[botIndex++].SetActive(true);
        }
    }
}