using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool IsPaused;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetButtonDown("Cancel"))
        {
            if (IsPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
      {
        Time.timeScale = 1;
        }
}
