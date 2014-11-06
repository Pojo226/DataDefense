﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class TimerScript : MonoBehaviour {

	Image timer;


	// Use this for initialization
	void Start () {
		timer = this.GetComponent ("Image") as Image;
	}
	
	// Update is called once per frame
	void Update () {
		timer.fillAmount = FixedValues.gameTime / FixedValues.Max_Time;
	}
}
