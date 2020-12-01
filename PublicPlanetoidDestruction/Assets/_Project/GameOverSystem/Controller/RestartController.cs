using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    [SerializeField] private GameObject asteroidDeathEffect;
    
    private void OnParticleCollision(GameObject other)
    {
        SceneManager.LoadScene("StartSceneSandbox", LoadSceneMode.Single);
    }
}