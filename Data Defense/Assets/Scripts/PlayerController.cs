using UnityEngine;
using System.Collections;

public class PlayerController : GameEntity {

    public int playerIndex;

	protected void Start(){
        base.Start();
	}
	
	// Update is called once per frame
	protected void Update(){
        float axis = 0;
        //float axis = Input.GetAxis("Horizontal" + playerIndex);
        if(axis != 0) {
            movement.x = axis;
        }

        //axis = Input.GetAxis("Vertical" + playerIndex);
        if(axis != 0) {
            movement.z = -axis;
        }
        
        base.Update();

        if (Input.GetButtonDown("X_" + playerIndex))
        {
            Debug.Log("Player" + playerIndex + ": X");
        }

        if (Input.GetButtonDown("Y_" + playerIndex))
        {
            Debug.Log("Player" + playerIndex + ": Y");
        }

        if (Input.GetButtonDown("B_" + playerIndex))
        {
            Debug.Log("Player" + playerIndex + ": B");
        }

        if (Input.GetButtonDown("A_" + playerIndex))
        {
            Debug.Log("Player" + playerIndex + ": A");
        }
	}


}
