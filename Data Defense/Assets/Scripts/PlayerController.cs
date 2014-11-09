using UnityEngine;
using System.Collections;

public class PlayerController : GameEntity {

    // The player's scan
    public ScanController scan;

    // Effectively, the players identification number
    public int playerIndex;

    // Call the base start method
	protected void Start(){
        base.Start();
	}
	

	// Update is called once per frame
	protected void Update(){

        // Movement controls
        float axis = Input.GetAxis("L_XAxis_" + playerIndex);
        if(axis != 0) {
            movement.x = axis;
        }

        axis = Input.GetAxis("L_YAxis_" + playerIndex);
        if(axis != 0) {
            movement.z = -axis;
        }
        
        // Call base update method for movement resolution
        base.Update();

        // Button resolution. Each Buttom will create a scan that targets a respective player
        if (Input.GetButtonDown("X_" + playerIndex))
        {

            //((GameObject)GameObject.Instantiate(ScanController.gameObject, transform.position, Quaternion.identity)).transform.parent = transform;
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
