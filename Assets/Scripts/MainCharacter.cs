using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float speed;
    public UnityEngine.Camera MainCamera;
    public PassPlat ReachedScore;

    void Start()
    {
        ReachedScore.restart();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed;
        }

        Vector3 viewPos = MainCamera.WorldToViewportPoint(transform.position);

        if (!(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
        {
            SceneManager.LoadScene("GameOver");
        }

        
    }
}
