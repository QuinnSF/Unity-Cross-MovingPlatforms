using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassPlat : MonoBehaviour
{
    private static int Score = 0;
    private bool pass = false;
    public Text scoreText;
    public GameObject HighScoreUI;
    private MovingPlatform TimeReset;
    private static int highest=0;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: "+Score;
        HighScoreUI.SetActive(false);
        if (Score < highest)
            if ((highest - Score) < 3)
                HighScoreUI.SetActive(true);
        
            
    }
public void restart()
    {
        TimeReset = new MovingPlatform();
        TimeReset.resetTime();
        Score = 0;
    }
    public int getHighScore()
    {
        return Score;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.name == "collision")&&(pass==false))
        {
            pass = true;
            Score++;
            if (Score > highest)
                highest = Score;
            HighScoreUI.SetActive(false);
            if (Score < highest)
                if ((highest - Score) < 4)
                {
                    highScoreText.text = "High Score: " + highest;
                    HighScoreUI.SetActive(true);
                }
        }
    }
}
