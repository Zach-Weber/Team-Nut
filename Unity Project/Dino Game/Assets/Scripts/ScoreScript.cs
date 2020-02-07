using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private static TextMesh scoreText;
    private static TextMesh highscoreText;
    public PlayerController playerController;

    public int score = 0;
    public int highscore = 0;


    // Start is called before the first frame update
    void Start()
    {
        highscoreText = GameObject.Find("highscoreNumber").GetComponent<TextMesh>();
        scoreText = GameObject.Find("scoreNumber").GetComponent<TextMesh>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateHighscore();
    }

    public void UpdateScore()
    {
        //if (playerController.started)
        {
            score = +(int)GameObject.Find("Player").transform.position.x;
            scoreText.text = score.ToString("D5");
        }
        return;
    }

    public void UpdateHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = highscore.ToString("D5");
        }
    }
}

