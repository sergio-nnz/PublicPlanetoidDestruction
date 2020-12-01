using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Project.HealthSystem.Core;
using _Project.SizeInverter.Controller;

public class MoonHealthController : MonoBehaviour
{
    [SerializeField] private int hitPoints = 1;
    [SerializeField] private GameObject moonDeathEffect;
    [SerializeField] private AsteroidSpawnerController spawner;
    [SerializeField] private SizeController sizeController;
    private MoonHealth health;
    
    private void Awake()
    {
        health = new MoonHealth(hitPoints);
    }

    private void OnParticleCollision(GameObject other)
    {
        health.Decrease();
        spawner.IsSpawnEnabled = false;
        if (health.IsDeath())
        {
            // TODO: Use an event trigger instead handling scene logic here
            var currentTransform = transform;
            var explosion = Instantiate(moonDeathEffect, currentTransform.position, currentTransform.rotation);
            explosion.transform.localScale = this.gameObject.transform.localScale;
            sizeController.IncrementEnabled = false;
            Destroy(gameObject);
        }
    }
}