using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeGamePause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ResumeUI;
    public static bool GameIsPause = false;
    private MovingPlatform Platform;
    void Start()
    {
        Platform = new MovingPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause != true)
            {//pause
                ResumeUI.SetActive(true);
                Time.timeScale = 0f;
                Platform.MakePause();
                GameIsPause = true;
            }
            else
                resume();

        }
    }

    public void resume()
    {
        ResumeUI.SetActive(false);
        Time.timeScale = 1f;
        Platform.MakeResume();
        GameIsPause = false;
    }
    public void Restart()
    {
        ResumeUI.SetActive(false);
        Time.timeScale = 1f;
        Platform.MakeResume();
        GameIsPause = false;
        SceneManager.LoadScene("GameOver");
    }
}
