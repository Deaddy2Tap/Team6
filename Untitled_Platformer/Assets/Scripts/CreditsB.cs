using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CreditsB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(quitgame);

        }
    }
    // Update is called once per frame
    void Update()
    {
       


        }
    public void quitgame()
    {
        Application.Quit();
    }

    private IEnumerator waitloadScene()
    {
        yield return new
            WaitForSecondsRealtime(10f);
        Application.Quit();
    }


}
