﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class SuperBarScript : MonoBehaviour {

	//Which players bar it is
	public int player;

	//Image for bar
	public Image bar;

	// Use this for initialization
	void Start () {
		bar = this.GetComponent ("Image") as Image;
	}
	
	// Update is called once per frame
	void Update () {
		//change the bar according to the player number
		bar.fillAmount = FixedValues.superScanVals[player] / FixedValues.Scan_Max;
	}
}