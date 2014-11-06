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
		switch (player) 
		{
			case 1:
				bar.fillAmount = FixedValues.superScan1 / FixedValues.Scan_Max;
				break;
			case 2:
				bar.fillAmount = FixedValues.superScan2 / FixedValues.Scan_Max;
				break;
			case 3:
				bar.fillAmount = FixedValues.superScan3 / FixedValues.Scan_Max;
				break;
			case 4:
				bar.fillAmount = FixedValues.superScan4 / FixedValues.Scan_Max;
				break;
			default:
				break;

		}
	}
}
