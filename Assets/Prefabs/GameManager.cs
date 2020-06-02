using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary> Manages the state of the whole application </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private string gameScene;
    public int HighScore=0;
    public Text scoreText;
    public MovingPlatform structure;

    public void Play()
    {
        StartCoroutine(LoadScene(gameScene));
    }
    public void rePlay()
    {
        structure.resetSpeed();
        StartCoroutine(LoadScene(gameScene));
    }
    private IEnumerator LoadScene(string sceneName)
    {
        Debug.Log("Loading game!");
        yield return new WaitForSeconds(.4f);
        SceneManager.LoadScene(sceneName);
    }

}