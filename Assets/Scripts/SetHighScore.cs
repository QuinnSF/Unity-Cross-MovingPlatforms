using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    private PassPlat reachedScore=new PassPlat();
    public static int HighScore;
    private int YourScore;
    public Text show;
    public void Start()
    {
        YourScore = reachedScore.getHighScore();
        HighScore = YourScore > HighScore ? YourScore : HighScore;
        show.text = "Your score: " + YourScore +"   High Score: "+ HighScore;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
