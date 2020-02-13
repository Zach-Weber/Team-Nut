/******************************
 * PlusGroundGenerate.cs
 * By: Conor Brennan
 * Last Edited: 2/7/2020
 * Description: randomly generates obstacles and ground terrain sprites
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusGroundGenerate : MonoBehaviour
{
    GameObject player;
    public GameObject plusGround;
    public GameObject plusSprite1;
    public GameObject plusSprite2;
    public GameObject plusSprite3;
    public GameObject plusSprite4;
    public GameObject plusSprite5;
    public GameObject log;
    public GameObject flyTrap;
    public GameObject snake;
    public GameObject frontLog;
    public GameObject plusGameOverText;
    public GameObject plusResetButton;
    public GameObject background;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public float plusGroundPos;
    public float plusPlayerPos;
    public float plusPos1;
    public float plusPos2;
    public float plusPos3;
    public float plusPos4;
    public float plusPos5;
    public float plusPos6;
    public float plusPos7;
    public float plusPos8;
    public float plusPos9;
    public float plusPos10;
    public float plusPos11;
    public float plusPos12;
    public float plusPos13;
    public float plusPos14;
    public float plusPos15;
    public float plusPos16;
    public float plusPos17;
    public float plusObstaclePos;
    public float plusObstacleRangeMax;
    public float plusObstacleRangeMin;
    public float backgroundPos;
    private GameObject plusSpriteSelect;
    private GameObject plusObstacleSelect;
    private int plusCloneCount;

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
            if (player.transform.position.x >= plusPlayerPos)
            {
                Instantiate(plusGround, new Vector3(plusGroundPos, -3, 0), Quaternion.identity);
                plusGroundPos += 10.804f;
                plusPlayerPos += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos1, -2.3f, 0), Quaternion.identity);
                plusPos1 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos2, -2.3f, 0), Quaternion.identity);
                plusPos2 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos3, -2.3f, 0), Quaternion.identity);
                plusPos3 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos4, -2.3f, 0), Quaternion.identity);
                plusPos4 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos5, -2.3f, 0), Quaternion.identity);
                plusPos5 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos6, -2.3f, 0), Quaternion.identity);
                plusPos6 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos7, -2.3f, 0), Quaternion.identity);
                plusPos7 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos8, -2.3f, 0), Quaternion.identity);
                plusPos8 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos9, -2.3f, 0), Quaternion.identity);
                plusPos9 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos10, -2.3f, 0), Quaternion.identity);
                plusPos10 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos11, -2.3f, 0), Quaternion.identity);
                plusPos11 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos12, -2.3f, 0), Quaternion.identity);
                plusPos12 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos13, -2.3f, 0), Quaternion.identity);
                plusPos13 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos14, -2.3f, 0), Quaternion.identity);
                plusPos14 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos15, -2.3f, 0), Quaternion.identity);
                plusPos15 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos16, -2.3f, 0), Quaternion.identity);
                plusPos16 += 10.804f;

                Instantiate(PlusSelectSprite(), new Vector3(plusPos17, -2.3f, 0), Quaternion.identity);
                plusPos17 += 10.804f;

                Instantiate(PlusSelectObstacle(), new Vector3(plusObstaclePos + Random.Range(plusObstacleRangeMin, plusObstacleRangeMax), -2.3f, 0), Quaternion.identity);
                plusObstaclePos += 15f;

                Instantiate(background, new Vector3(backgroundPos, 0.2f, 5), Quaternion.identity);
                backgroundPos += 27.86f;
            }

            if (PlayerController.dead == true && plusCloneCount == 0)
            {
                GameObject camera = FindObjectOfType<CameraScript>().gameObject;
                float cameraPos = camera.transform.position.x;

                Instantiate(plusGameOverText, new Vector3(cameraPos, 0.6f, 0), Quaternion.identity);
                Instantiate(plusResetButton, new Vector3(0, 0, 0), Quaternion.identity);
                plusCloneCount++;
            }
            else if (PlayerController.dead != true)
                plusCloneCount = 0;

        }
    }

    private GameObject PlusSelectSprite()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                plusSpriteSelect = plusSprite1;
                break;
            case 2:
                plusSpriteSelect = plusSprite2;
                break;
            case 3:
                plusSpriteSelect = plusSprite3;
                break;
            case 4:
                plusSpriteSelect = plusSprite4;
                break;
            case 5:
                plusSpriteSelect = plusSprite5;
                break;
        }
        return plusSpriteSelect;
    }

    private GameObject PlusSelectObstacle()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                plusObstacleSelect = log;
                break;
            case 2:
                plusObstacleSelect = flyTrap;
                break;
            case 3:
                plusObstacleSelect = frontLog;
                break;
                //case 4:
                //plusObstacleSelect = snake;
                //break;
        }
        return plusObstacleSelect;
    }
}
