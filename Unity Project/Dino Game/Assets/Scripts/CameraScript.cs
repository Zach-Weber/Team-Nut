﻿/******************************
 * CameraScript.cs
 * By: Conor Brennan
 * Last Edited: 1/30/2020
 * Description: script that makes main camera follow the player along their x position
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float camPos;
    GameObject player;
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
            //creates new temp vector equal to current camera position
            Vector3 newPos = transform.position;
            //updates temp vector's x to match x of player
            newPos.x = player.transform.position.x;
            //offsets temp vector
            newPos.x += camPos;
            //sets camera position to temp vector
            transform.position = newPos;
        }
    }
}
