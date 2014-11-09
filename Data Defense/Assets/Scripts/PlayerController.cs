using UnityEngine;
using System.Collections;

public class PlayerController : GameEntity {

    // The player's scan
    public ScanController scanPrefab;
    public ScanController scan;
    public bool canFire;

    // Effectively, the players identification number
    public int playerIndex;

    // Call the base start method
	protected void Start(){
        canFire = true;
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
                if (playerIndex != 1 && canFire == true)
                    setScan('x');

            Debug.Log("Player" + playerIndex + ": X");
        }

        if (Input.GetButtonDown("Y_" + playerIndex))
        {
            if (playerIndex != 2 && canFire == true)
                setScan('y');

            Debug.Log("Player" + playerIndex + ": Y");
        }

        if (Input.GetButtonDown("B_" + playerIndex))
        {
            if (playerIndex != 3 && canFire == true)
                setScan('b');

            Debug.Log("Player" + playerIndex + ": B");
        }

        if (Input.GetButtonDown("A_" + playerIndex))
        {
            if (playerIndex != 4 && canFire == true)
                setScan('a');

            Debug.Log("Player" + playerIndex + ": A");
        }
		//Used to manage the power bars

	}

    void setScan(char buttonDown)
    {
        Transform tempTransform = transform;
        scan = Instantiate(scanPrefab, tempTransform.position, Quaternion.identity) as ScanController;
        canFire = false;
        Vector3 newPos = scan.transform.position;
        newPos.y = 10;
        scan.transform.position = newPos;



        switch (buttonDown)
        {
            case 'x':
                scan.setTarget(1);
                scan.myPlayer = playerIndex;
                break;
            case 'y':
                scan.setTarget(2);
                scan.myPlayer = playerIndex;
                break;
            case 'b':
                scan.setTarget(3);
                scan.myPlayer = playerIndex;
                break;
            case 'a':
                scan.setTarget(4);
                scan.myPlayer = playerIndex;
                break;
            default:
                break;
        }
        

    }

}
