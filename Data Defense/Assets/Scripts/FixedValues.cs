using UnityEngine;
using System.Collections;

public class FixedValues : MonoBehaviour {

    // Set the FixedValues instance to itself
    private static FixedValues instance;
    private void Awake(){ instance = this; }

    public Transform aiContainer;
    public static Transform AIContainer { get { return instance.aiContainer;  } }

    // Enemy types can be specified by numbers now
    public enum Enemy_Types { Data, Virus, Program }

	//Conatant for round times
	public static float Max_Time = 30.00f;

	//var for current time left
	public static float gameTime;

	//Amount of "Scan points" needed to fill the super scan bar
	public static float Scan_Max = 10.0f;

	//int representing super scan progress for each player
	public static float[] superScanVals = { 0.0f, 0.0f, 0.0f, 0.0f };

	public static int[] playerScores = { 0, 0, 0, 0 };

    // This is so that scans can reset the "canFire" variable
	public PlayerController[] players;

	// Number of enemies on screen. Used for wave spawning
	public static int enemyNum = 0;

	//Wave number
	public static int waveNum;
}
