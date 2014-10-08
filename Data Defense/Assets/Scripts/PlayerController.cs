using UnityEngine;
using System.Collections;

public class PlayerController : GameEntity {

    public int playerIndex;

	protected void Start(){
        base.Start();
	}
	
	// Update is called once per frame
	protected void Update(){
        float axis = Input.GetAxis("Horizontal" + playerIndex);
        if(axis != 0) {
            movement.x = axis;
        }

        axis = Input.GetAxis("Vertical" + playerIndex);
        if(axis != 0) {
            movement.z = -axis;
        }
        
        base.Update();
	}
}
