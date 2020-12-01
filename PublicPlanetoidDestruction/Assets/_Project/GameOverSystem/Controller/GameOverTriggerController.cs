using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTriggerController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void OnDestroy()
    {
        gameOverScreen.SetActive(true);
    }
}
