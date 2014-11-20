using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	private Text text;

	public int playerIndex;

	private void Start(){
		text = GetComponent<Text>();
	}

	private void Update(){
		text.text = FixedValues.playerScores[playerIndex].ToString();
	}
}
