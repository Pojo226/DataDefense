using UnityEngine;
using System.Collections;

public class PlayerController : GameEntity {

    public ScanController scan;
    public int playerIndex;

	protected void Awake(){
        base.Awake();
	}
	
	// Update is called once per frame
    protected override void FixedUpdate(){
        float axis = Input.GetAxis("L_XAxis_" + playerIndex);
        if (axis != 0)
        {
            movement.x = axis;
        }

        axis = Input.GetAxis("L_YAxis_" + playerIndex);
        if (axis != 0)
        {
            movement.z = -axis;
        }

        base.FixedUpdate();

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
