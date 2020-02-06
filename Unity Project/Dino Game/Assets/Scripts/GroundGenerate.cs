/******************************
 * GroundGenerate.cs
 * By: Conor Brennan
 * Last Edited: 1/31/2020
 * Description: simple ground generation, not random, just for prototype
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
    public float groundPos;
    public float playerPos;
    public float spritePos1;
    public float spritePos2;
    public float spritePos3;
    public float spritePos4;
    private GameObject spriteSelect;
    

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
            }
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
}
