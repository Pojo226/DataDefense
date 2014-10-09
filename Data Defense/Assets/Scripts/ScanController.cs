using UnityEngine;
using System.Collections;

public class ScanController : GameEntity {

	// Use this for initialization
	void Start () {
        base.Start();

	}
	
	// Update is called once per frame
	void Update () {
        movement = new Vector3(1, 0, 0);
        base.Update();

	}
}
