﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour {

    public WordManager wordManager;
    public float spawnDelay = 10f;
    private float nextWordTime = 0f;
  
	void Update () {
		
        if (Time.time>=nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + spawnDelay;
            //spawnDelay *= 0.9f; 
        }
	}
}