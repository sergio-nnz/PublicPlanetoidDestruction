using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using _Project.GunSystem.Core;

public class GunSystem : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    
    private Gun rightGun;
    private Gun leftGun;
    
    
    private void Awake()
    {
        rightGun = new Gun(SteamVR_Input_Sources.RightHand, trigger, rightSpawnPoint);
        leftGun = new Gun(SteamVR_Input_Sources.LeftHand, trigger, leftSpawnPoint);
    }

    //TODO: Replace update with for coroutine
    void Update()
    {
        rightGun.ShootProjectile();
        leftGun.ShootProjectile();
    }
}
