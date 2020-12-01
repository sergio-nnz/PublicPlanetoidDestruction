using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Project.GunSystem.Core;
using _Project.GunSystem.Core.Data;

public class ProjectileSystem : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    private ProjectileSpawner spawner;

    public static ProjectileSystem Instance { get; private set; }

    // TODO: Use an observer pattern instead of a singleton
    private void Awake()
    {   
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
        spawner = new ProjectileSpawner(projectile);
    }

    public void SpawnAt(Transform projectileTransform)
    {
        ProjectileProperties properties = new ProjectileProperties
        {
            position = projectileTransform.position, rotation = projectileTransform.rotation
        };

        spawner.SpawnProjectileWithProperties(properties);
    }
}