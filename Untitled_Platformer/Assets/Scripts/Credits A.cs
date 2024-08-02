using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI; // Add this for the Button component

public class Creditsa : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(LoadScene);
            StartCoroutine("waitloadScene");
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void quitgame()
    {
        Application.Quit();
    }
    private IEnumerator waitloadScene()
    {
        yield return new
            WaitForSecondsRealtime(25.0f);
        Application.Quit();
    }
}