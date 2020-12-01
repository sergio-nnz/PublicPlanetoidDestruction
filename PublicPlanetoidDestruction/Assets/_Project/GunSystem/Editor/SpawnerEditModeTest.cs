using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using _Project.GunSystem.Core;
using _Project.GunSystem.Core.Builders;
using _Project.GunSystem.Core.Data;
using Random = UnityEngine.Random;

namespace GunSystem.EditModeTests
{
    public class SpawnerEditModeTest
    {
        private ProjectileSpawner spawner;
        private GameObject templateProjectile;
        private const string projectileName = "testProjectile";

        [SetUp]
        public void SetupUnityScene()
        {
            templateProjectile = GameObject.CreatePrimitive(PrimitiveType.Cube);
            templateProjectile.name = projectileName;

            spawner = new ProjectileSpawner(templateProjectile);
        }

        [TearDown]
        public void TearDownUnityScene()
        {
            spawner.ClearProjectiles();
        }


        [Test]
        public void SpawnProjectileCreatesANewInstanceOfAGivenGameObject()
        {
            int totalProjectiles = Random.Range(1, 10);
            
            SpawnProjectiles(totalProjectiles);
            
            Assert.AreEqual(totalProjectiles, spawner.GetTotalProjectiles());
        }
        
        [Test]
        public void SpawnProjectileCreatesANewInstanceOfAGivenGameObjectAtAGivenLocation()
        {
            //expectedTransform.position;

            ProjectileProperties properties = new ProjectileProperties();
            properties.position = new Vector3(1.0f, 1.0f, 1.0f);
            properties.rotation = new Quaternion(0.6f, 0.6f, 0.6f, 0.0f);
            
            spawner.SpawnProjectileWithProperties(properties);

            GameObject actualProjectile = spawner.GetProjectiles().First();
            
            Assert.AreEqual(properties.position, actualProjectile.transform.position);
            Assert.AreEqual(properties.rotation.x, actualProjectile.transform.rotation.x, 0.1);
            Assert.AreEqual(properties.rotation.y, actualProjectile.transform.rotation.y, 0.1);
            Assert.AreEqual(properties.rotation.z, actualProjectile.transform.rotation.z, 0.1);
            Assert.AreEqual(properties.rotation.w, actualProjectile.transform.rotation.w, 0.1);
        }
        
        [Test]
        public void SpawnProjectileWontSpawnMoreThanALimitedAmountOfObjects()
        {
            Assert.True(false);
        }
        
        [Test]
        public void SpawnProjectileWillTriggerAnEventWhenALimitedAmountOfObjectsIsReached ()
        {
            Assert.True(false);
        }

        private void SpawnProjectiles(int totalSpawnTimes)
        {
            for (int i = 0; i < totalSpawnTimes; i++)
            {
                spawner.SpawnProjectile();
            }
        }
    }
}
