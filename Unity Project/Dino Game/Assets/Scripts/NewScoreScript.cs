using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewScoreScript : MonoBehaviour
{
    private static Text Score;
    private static Text HighScore;
    public PlayerController playerController;

    public int score = 0;
    public int highScore = 0;


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
    }

    public void UpdateScore()
    {
        if (playerController.started)
        {
            score = +(int)GameObject.Find("Player").transform.position.x;
            Score.text = score.ToString("D5");
        }
        return;
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            HighScore.text = highScore.ToString("D5");
        }
    }
}

