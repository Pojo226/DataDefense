using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    // Set the main camera field of view to 80 degrees
		Camera.main.fieldOfView = 85;
	}
}
