﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.GameOver)
        {
            transform.position += new Vector3(5f * Time.deltaTime, 0, 0); //This line will make the camera follow the player
        }
        
    }
}
