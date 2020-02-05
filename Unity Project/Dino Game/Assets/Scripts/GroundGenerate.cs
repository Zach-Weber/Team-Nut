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
    public GameObject ground1;
    public GameObject ground2;
    public GameObject ground3;
    public int groundPos;
    public int playerPos;

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
                switch (Random.Range(1, 3))
                {
                    case 1: // Ground w/ no bumps
                        Instantiate(ground1, new Vector3(groundPos, 0, 0), Quaternion.identity);
                        groundPos += 30;
                        playerPos += 30;
                        break;

                    case 2: // Ground w/ Double Bumps
                        Instantiate(ground2, new Vector3(groundPos, 0, 0), Quaternion.identity);
                        groundPos += 30;
                        playerPos += 30;
                        break;

                    case 3: // Ground w/ Bump and Divot
                        Instantiate(ground3, new Vector3(groundPos, 0, 0), Quaternion.identity);
                        groundPos += 30;
                        playerPos += 30;
                        break;
                }
            }
        }
    }
}
