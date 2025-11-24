using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public int maxParticles = 100;
    public float particleUpdateRate = 3;
    public List<ParticleSystem> particles;
    public BurgerManager burger;
    
    private bool hasCows = false;
    private bool hasTomatos = false;
    
    void Start()
    {
        InvokeRepeating(nameof(UpdateParticles), 0, particleUpdateRate);
    }

    void UpdateParticles()
    {
        foreach (var p in particles)
        {
            var emission = p.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(
                Mathf.Min((int)Math.Ceiling(burger.burgersPerSecond), particleUpdateRate)
            );

            if (!hasCows || !hasTomatos)
            {
                foreach (var b in burger.allBuildings)
                {
                    if (b.name.Contains("Cow"))
                    {
                        hasCows = true;
                        particles[1].Play();
                    }

                    if (b.name.Contains("Tomato"))
                    {
                        hasTomatos = true;
                        particles[2].Play();
                    }
                }
                
            }
        }
    }
}
