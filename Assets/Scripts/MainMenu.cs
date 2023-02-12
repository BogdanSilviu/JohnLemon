using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string level;
    public TextMeshProUGUI timeDisplay;
    void Start()
    {
        timeDisplay.text = GameEnding.timeValue;
        GameEnding.time = 0f;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(level);
        Observer.abilityCharges = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
