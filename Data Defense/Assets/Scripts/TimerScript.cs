﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class TimerScript : MonoBehaviour {

	Image timer;

	float timePassed;

	// Use this for initialization
	void Start () {
		timer = this.GetComponent ("Image") as Image;
		timePassed = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "GetReady") {

			timePassed += Time.deltaTime;

			timer.fillAmount = timePassed / 2.7f;

		} else {

			timer.fillAmount = FixedValues.gameTime / FixedValues.Max_Time;
		}

	}
}
