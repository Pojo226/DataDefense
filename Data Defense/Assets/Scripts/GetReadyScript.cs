using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetReadyScript : MonoBehaviour {

	private Text text;

	private int timeLeft;
	private float timePassed;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		timeLeft = 0;
		timePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {

		timePassed += Time.deltaTime;

		timeLeft = (int)(4.7f - timePassed);

		if (timeLeft < 2) {
						text.text = "GET READY\nGO!";
				} else {
						text.text = "GET READY\n" + (timeLeft - 1);
				}

	}
}
