using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        Debug.Log("Player Wins!");
    }
}