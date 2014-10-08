using UnityEngine;
using System.Collections;

public class PlayerController : GameEntity {

    public int playerIndex;

	protected void Start(){
        base.Start();
	}
	
	// Update is called once per frame
	protected void Update(){
        float axis = Input.GetAxis("L_XAxis_" + playerIndex);
        if(axis != 0) {
            movement.x = axis;
        }

        axis = Input.GetAxis("L_YAxis_" + playerIndex);
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
