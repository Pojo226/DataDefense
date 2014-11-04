using UnityEngine;
using System.Collections;

public class ScanController : GameEntity {

	// Use this for initialization
    protected override void Awake() {
        base.Awake();

	}
	
	// Update is called once per frame
	protected void FixedUpdate () {
        movement = new Vector3(1, 0, 0);
        base.FixedUpdate();

	}
}
