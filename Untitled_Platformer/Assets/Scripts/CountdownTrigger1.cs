using UnityEngine;
using TMPro;  // Import TextMeshPro namespace
using System.Collections;
using UnityEngine.SceneManagement;
public class CountdownTrigger2 : MonoBehaviour
{
    public float countdownTime = 60f;  // Countdown time in seconds
    public TextMeshProUGUI countdownText;  // Reference to the TextMeshProUGUI component to display the countdown

    private bool isCountingDown = false;

    private void Start()
    {
        Debug.Log("CountdownTrigger script started");  // Debug log for script start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered by: " + other.name);  // Debug log for entering the trigger

        if (other.CompareTag("Player") && !isCountingDown)
        {
            Debug.Log("Player entered the trigger");  // Debug log for player entering the trigger
            StartCoroutine(StartCountdown());
            if (countdownTime < 50)
            {
                SceneManager.LoadScene("win");
            }
        }
        else
        {
            Debug.Log("Entered by non-player or already counting down");
        }
    }

    private IEnumerator StartCountdown()
    {
        Debug.Log("Countdown started");  // Debug log for countdown start
        isCountingDown = true;
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            if (countdownText != null)
            {
                countdownText.text = remainingTime.ToString("F2");  // Display remaining time with 2 decimal places
            }

            Debug.Log($"Time remaining: {remainingTime} seconds");  // Debug log for remaining time

            yield return new WaitForSeconds(1f);
            remainingTime -= 1f;
        }

        // Countdown has ended
        if (countdownText != null)
        {
            countdownText.text = "0.00";
        }

        Debug.Log("Countdown has ended");  // Debug log for countdown end
        CountdownEnded();
        isCountingDown = false;
    }

    private void CountdownEnded()
    {
        // Code to execute when the countdown ends
        Debug.Log("Executing CountdownEnded method");  // Debug log for CountdownEnded method
    }
    
}