/******************************
 * PrototypeGenerate.cs
 * By: Conor Brennan
 * Last Edited: 1/31/2020
 * Description: simple ground generation, not random, just for prototype
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeGenerate : MonoBehaviour
{
    GameObject player;
    public GameObject groundSection;
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
     if(player != null)
        {
            if(player.transform.position.x >= playerPos)
            {
                Instantiate(groundSection, new Vector3(groundPos, 0, 0), Quaternion.identity);
                groundPos += 30;
                playerPos += 30;
            }
        }   
    }
}
