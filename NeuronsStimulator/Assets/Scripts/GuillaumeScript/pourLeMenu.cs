﻿using UnityEngine;
using System.Collections;


public class pourLeMenu : MonoBehaviour {

    public GameObject canvas;
    public GameObject animation;
    public GameObject skip;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void leBtnStart()
    {
        canvas.SetActive(false);
        animation.GetComponent<Animator>().enabled = true;
        skip.SetActive(true);
        //Application.LoadLevel("Salameche");
    }

    public void leBtnTuto()
    {
        Application.LoadLevel("tutoMenu");
    }
}