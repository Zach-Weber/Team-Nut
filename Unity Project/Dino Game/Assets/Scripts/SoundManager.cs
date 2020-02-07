/******************************
 * SoundManager.cs
 * By: Conor Brennan
 * Last Edited: 2/6/2020
 * Description: controls all sound effects and music
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Jump;
    public static AudioClip Hit;
    public static AudioClip Point;
    static AudioSource AudioSrc;
    // Start is called before the first frame update
    void Start()
    {
        Jump = Resources.Load<AudioClip>("Jump");
        Hit = Resources.Load<AudioClip>("Hit");
        Point = Resources.Load<AudioClip>("Point");
        AudioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                AudioSrc.PlayOneShot(Jump);
                break;
            case "Hit":
                AudioSrc.PlayOneShot(Hit);
                break;
            case "Point":
                AudioSrc.PlayOneShot(Point);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
