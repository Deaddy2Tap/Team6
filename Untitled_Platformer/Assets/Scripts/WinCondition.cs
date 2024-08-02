using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Import SceneManager namespace

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
        SceneManager.LoadScene("Win");  // Load the "Win" scene
    }
}