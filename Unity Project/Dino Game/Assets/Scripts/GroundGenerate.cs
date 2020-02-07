/******************************
 * GroundGenerate.cs
 * By: Conor Brennan
 * Last Edited: 2/7/2020
 * Description: randomly generates obstacles and ground terrain sprites
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerate : MonoBehaviour
{
    GameObject player;
    public GameObject ground;
    public GameObject groundSprite1;
    public GameObject groundSprite2;
    public GameObject groundSprite3;
    public GameObject smallCactus;
    public GameObject bigCactus;
    public GameObject tripleCactus;
    public GameObject quadCactus;
    public GameObject GameOverText;
    public GameObject ResetButton;
    public GameObject canvas;
    public float groundPos;
    public float playerPos;
    public float spritePos1;
    public float spritePos2;
    public float spritePos3;
    public float spritePos4;
    public float obstaclePos;
    public float obstacleRangeMax;
    public float obstacleRangeMin;
    private GameObject spriteSelect;
    private GameObject obstacleSelect;
    private int cloneCount;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.x >= playerPos)
            {
                Instantiate(ground, new Vector3(groundPos, -3, 0), Quaternion.identity);
                groundPos += 10.248f;
                playerPos += 10.248f;

                Instantiate(SelectSprite(), new Vector3(spritePos1, -2.36f, 0), Quaternion.identity);
                spritePos1 += 10.248f;

                Instantiate(groundSprite1, new Vector3(spritePos2, -2.36f, 0), Quaternion.identity);
                spritePos2 += 10.248f;

                Instantiate(SelectSprite(), new Vector3(spritePos3, -2.36f, 0), Quaternion.identity);
                spritePos3 += 10.248f;

                Instantiate(groundSprite1, new Vector3(spritePos4, -2.36f, 0), Quaternion.identity);
                spritePos4 += 10.248f;

                
                Instantiate(SelectObstacle(), new Vector3(obstaclePos + Random.Range(obstacleRangeMin, obstacleRangeMax), -2, 0), Quaternion.identity);
                obstaclePos += 15f;
            }

            if (PlayerController.dead == true && cloneCount == 0)
            {
                GameObject camera = FindObjectOfType<CameraScript>().gameObject;
                float cameraPos = camera.transform.position.x;

                Instantiate(GameOverText, new Vector3(cameraPos, -1, 0), Quaternion.identity);
                Instantiate(ResetButton, new Vector3(0, 0, 0), Quaternion.identity);
                cloneCount++;
            }
            else if (PlayerController.dead != true)
                cloneCount = 0;

        }
    }

    private GameObject SelectSprite()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                spriteSelect = groundSprite1;
                break;
            case 2:
                spriteSelect = groundSprite2;
                break;
            case 3:
                spriteSelect = groundSprite3;
                break;
        }
        return spriteSelect;
    }

    private GameObject SelectObstacle()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                obstacleSelect = smallCactus;
                break;
            case 2:
                obstacleSelect = bigCactus;
                break;
            case 3:
                obstacleSelect = tripleCactus;
                break;
            case 4:
                obstacleSelect = quadCactus;
                break;
        }
        return obstacleSelect;
    }
}
