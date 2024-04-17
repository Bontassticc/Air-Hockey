using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text countdownText;
    public float countdownDuration = 3f;

    private float countdownTimer;
    private bool timer_is_started = false;
    void Start()
    {
        countdownTimer = countdownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer_is_started == true)  //countdown timer for main menue and start of time
        {
            countdownTimer -= Time.deltaTime;

            // Update the countdown text
            countdownText.text = Mathf.CeilToInt(countdownTimer).ToString(); //

            // Start the game when countdown reaches zero
            if (countdownTimer <= 0f)
            {
                GameMode(); //name of scene it'll come back to
            }
        }
    }


    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GameMode()
    {
        SceneManager.LoadScene(1);
    }
    public void Start_Timer()
    {
        timer_is_started = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
