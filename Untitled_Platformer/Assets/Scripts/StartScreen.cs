using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI; // Add this for the Button component

public class StartScreen : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(LoadScene);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("FinalLevel2");
    }
}