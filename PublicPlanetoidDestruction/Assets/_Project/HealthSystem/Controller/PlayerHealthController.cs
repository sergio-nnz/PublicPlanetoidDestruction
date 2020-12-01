using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using _Project.HealthSystem.Core;

namespace _Project.HealthSystem.Controller
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private int playerHitPoints = 1;
        private PlayerHealth playerHealth;

        private void Awake()
        {
            playerHealth = new PlayerHealth(playerHitPoints);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Shootable")) return;
            playerHealth.Decrease();
            if (playerHealth.IsDeath())
            {
                // TODO: Use an event trigger instead handling scene logic here
                SceneManager.LoadScene("SpaceSandbox", LoadSceneMode.Single);
            }
        }   
    }
}
