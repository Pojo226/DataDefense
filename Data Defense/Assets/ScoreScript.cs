using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "WAVE REACHED: " + FixedValues.waveNum + "\n\nPLAYER 1 SCORE: " + FixedValues.playerScores[0] + "\nPLAYER 2 SCORE: " + FixedValues.playerScores[1] + "\nPLAYER 3 SCORE: " + FixedValues.playerScores[2] + "\nPLAYER 4 SCORE: " + FixedValues.playerScores[3] + "\n\n\nPRESS A TO RETURN TO MAIN MENU";
	}
}
