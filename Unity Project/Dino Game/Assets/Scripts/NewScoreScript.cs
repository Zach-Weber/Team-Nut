/******************************
 * NewScoreScript.cs
 * By: Conor Brennan & Zach Weber
 * Last Edited: 2/7/2020
 * Description: increases score based on player position and saves highscore
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewScoreScript : MonoBehaviour
{
    private static Text Score;
    private static Text HighScore;
    private float timer;
    public PlayerController playerController;

    int score = 0;
    public int highScore = 0;
    public float scoreSpeed = 0.5f;
    private bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        HighScore = GameObject.Find("HighScore").GetComponent<Text>();
        Score = GameObject.Find("Score").GetComponent<Text>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateScore();
        UpdateHighScore();

        if (score % 100 != 0)
            played = false;
        if(score > 0 && (score % 100) == 0 && PlayerController.started == true && played == false)
        {
            SoundManager.PlaySound("Point");
            played = true;
        }

    }

    public void UpdateScore()
    {
        if (PlayerController.started == true)
        {
            /**
            score = 100;
            timer = Time.deltaTime;
            if (timer > scoreSpeed)
            {
                score += 1;
                Debug.Log("scored");
                
                timer = 0;
            }**/
            //Debug.Log(Time.deltaTime);

            score += (int) (Time.deltaTime * 100);

            // score = +(int)GameObject.Find("Player").transform.position.x;
            // score += 4;
            Score.text = score.ToString("D5");

        }
        return;
    }

    public void UpdateHighScore()
    {
        HighScore.text = PlayerPrefs.GetInt("SavedScore").ToString("D5");
        highScore = PlayerPrefs.GetInt("SavedScore");
        if (score > highScore)
        {
            highScore = score;
            HighScore.text = highScore.ToString("D5");
            PlayerPrefs.SetInt("SavedScore", highScore);
        }
    }
}

