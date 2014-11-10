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
	public static float Scan_Max = 100.00f;

	//int representing super scan progress for each player
	public static float superScan1 = 70.00f;
	public static float superScan2 = 100.00f;
	public static float superScan3 = 50.00f;
	public static float superScan4 = 90.00f;

    // This is so that scans can reset the "canFire" variable
    public PlayerController player1;
    public PlayerController player2;
    public PlayerController player3;
    public PlayerController player4;
}
