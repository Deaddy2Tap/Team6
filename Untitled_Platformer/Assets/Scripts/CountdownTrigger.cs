using UnityEngine;
using TMPro;  // Import TextMeshPro namespace
using System.Collections;
using UnityEngine.SceneManagement;
public class CountdownTrigger : MonoBehaviour
{
    public float countdownTime = 60f;  // Countdown time in seconds
    public TextMeshProUGUI countdownText;  // Reference to the TextMeshProUGUI component to display the countdown
    public GameObject winConditionTrigger; // Reference to the win condition trigger GameObject

    private bool isCountingDown = false;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !isCountingDown)
        {
            StartCoroutine(StartCountdown());
        }
        else
        {

        }
    }

    private IEnumerator StartCountdown()
    {
        isCountingDown = true;
        float remainingTime = countdownTime;

        if (winConditionTrigger != null)
        {
            winConditionTrigger.SetActive(true); // Activate the win condition trigger
        }

        while (remainingTime > 0)
        {
            if (countdownText != null)
            {
                countdownText.text = remainingTime.ToString("F2");  // Display remaining time with 2 decimal places
            }
            yield return new WaitForSeconds(1f);
            remainingTime -= 1f;
        }

        // Countdown has ended
        if (countdownText != null)
        {
            countdownText.text = "0.00";
        }
  // Debug log for countdown end
        CountdownEnded();
        isCountingDown = false;
    }

    private void CountdownEnded()
    {
<<<<<<< Updated upstream
        // Code to execute when the countdown ends
        Debug.Log("Executing CountdownEnded method");  // Debug log for CountdownEnded method
        SceneManager.LoadScene("Win");
=======
        // Code to execute when the countdown ends  // Debug log for CountdownEnded method
        GameOver();  // Call the game over method
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");  // Debug log for game over
        // Implement your game over logic here (e.g., show a game over screen, reset the level, etc.)
>>>>>>> Stashed changes
    }
}