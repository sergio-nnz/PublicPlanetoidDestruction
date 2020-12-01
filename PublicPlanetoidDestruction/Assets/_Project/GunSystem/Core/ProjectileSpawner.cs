using System.Collections.Generic;
using UnityEngine;
using _Project.GunSystem.Core.Data;

namespace _Project.GunSystem.Core
{
    public class ProjectileSpawner
    {
        private GameObject projectileTemplate;
        private HashSet<GameObject> projectiles;
        
        public ProjectileSpawner(GameObject projectileTemplate)
        {
            this.projectileTemplate = projectileTemplate;
            projectiles = new HashSet<GameObject>();
        }

        public void SpawnProjectile()
        {
            var projectileClone = Object.Instantiate(projectileTemplate);
            projectiles.Add(projectileClone);
        }

        public void SpawnProjectileWithProperties(ProjectileProperties properties)
        {
            var projectileClone = Object.Instantiate(projectileTemplate, properties.position, properties.rotation);
            projectiles.Add(projectileClone);
        }

        
        public HashSet<GameObject> GetProjectiles()
        {
            return projectiles;
        }

        public int GetTotalProjectiles()
        {
            return projectiles.Count;
        }

        public void ClearProjectiles()
        {
            var currentProjectiles = new HashSet<GameObject>(projectiles);
            projectiles = new HashSet<GameObject>();
            
            foreach (var projectile in currentProjectiles)
            {
                Object.DestroyImmediate(projectile);
            }
        }

    }
}