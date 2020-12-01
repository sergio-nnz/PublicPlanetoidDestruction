using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Project.SceneLoaderSystem.Controller;

public class SceneLoadingTrigger : MonoBehaviour
{
    [SerializeField] private RocketLaunchController rockerLauncherController;

    private void OnCollisionEnter(Collision other)
    {
        EnableSceneLoading();
    }

    private void EnableSceneLoading()
    {
        rockerLauncherController.AllowSceneLoad();
    }
}
