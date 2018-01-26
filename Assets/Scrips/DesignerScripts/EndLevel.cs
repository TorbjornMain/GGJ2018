﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {
    public string nextLevel;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Robot")
        {
            Debug.Log("Add a check to make sure that the robot is currently being controlled by the player");
            SceneManager.LoadScene(nextLevel);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}