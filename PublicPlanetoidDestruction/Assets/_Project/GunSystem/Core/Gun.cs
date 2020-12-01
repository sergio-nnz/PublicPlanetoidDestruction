using System;
using UnityEngine;
using Valve.VR;

namespace _Project.GunSystem.Core
{
    public class Gun
    {
        private SteamVR_Input_Sources source;
        private SteamVR_Action_Boolean trigger;
        private Transform spawnPoint;
        
        private GameObject bulletObject;
        private bool triggerPressed = false;
        
        public Gun(SteamVR_Input_Sources source, SteamVR_Action_Boolean trigger, Transform spawnPoint)
        {
            this.source = source;
            this.trigger = trigger;
            this.spawnPoint = spawnPoint;
        }
        
        public void ShootProjectile()
        {       
            if (!trigger.GetState(source))
            {
                triggerPressed = false;
            }

            else
            {
                if (!triggerPressed)
                {
                    Debug.Log($"Shoot {source.ToString()}");
                    ProjectileSystem.Instance.SpawnAt(spawnPoint);
                    triggerPressed = true;
                }
            }
        }
    }
}
