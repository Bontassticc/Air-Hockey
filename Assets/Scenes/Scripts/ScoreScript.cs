using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    
    public int Player_Scorevalue = 0;
    public int Enemy_Scorevalue = 0;
    [SerializeField] private Text PlayerScore;
    [SerializeField] private Text EnemyScore;
    [SerializeField] private GameObject winnerMsg;
    [SerializeField] private GameObject loserMsg;
    private puck puck_gameObj;
    // Start is called before the first frame update
    void Start()
    {
        puck_gameObj = FindObjectOfType<puck>();
    }

    // Update is called once per frame
    void Update()
    {
      PlayerScore.text = "Score"+ Player_Scorevalue;
      EnemyScore.text = "Score"+ Enemy_Scorevalue;


        if(Player_Scorevalue >= 5)
        {
            print("Winner");
            winnerMsg.SetActive(true);
           // puck_gameObj.ResetPuck();
            Enemy_Scorevalue = 0;
            Player_Scorevalue = 0;
            //set active a You Win message
            //A button that says 'Play Again', the button takes you to MainMenu (sceneManagement 0)
        }
        else if(Enemy_Scorevalue >= 5)
        {
            print("Loser");
            loserMsg.SetActive(true);
            //puck_gameObj.ResetPuck();
            Enemy_Scorevalue = 0;
            Player_Scorevalue = 0;
            //set active a You're A Loser, Chump, message
            //A button that says 'Play Again', the button takes you to MainMenu (sceneManagement 0)
        }
    }

    public void PointDeduction(int howMany)
    {
        Player_Scorevalue = Player_Scorevalue - howMany;
    }


    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    void GameMode()
    {
        SceneManager.LoadScene(1);
    }
}
