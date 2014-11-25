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
        float axis = Input.GetAxis("L_XAxis_" + (playerIndex + 1));
        if(axis != 0) {
            movement.x = axis;
        }

		axis = Input.GetAxis("L_YAxis_" + (playerIndex + 1));
		if(axis != 0) {
            movement.z = -axis;
        }
        
        // Call base update method for movement resolution
        base.Update();

        // Button resolution. Each Buttom will create a scan that targets a respective player
		if (Input.GetButtonDown("X_" + (playerIndex + 1)))
		{
            if (playerIndex != 0 && canFire == true){
                SetScan('x');
			}
        }

		if (Input.GetButtonDown("Y_" + (playerIndex + 1)))
		{
            if (playerIndex != 1 && canFire == true){
                SetScan('y');
			}
        }

		if (Input.GetButtonDown("B_" + (playerIndex + 1)))
		{
            if (playerIndex != 2 && canFire == true){
                SetScan('b');
			}
        }

		if (Input.GetButtonDown("A_" + (playerIndex + 1)))
		{
            if(playerIndex != 3 && canFire == true){
				SetScan('a');
			}
        }


	}

    void SetScan(char buttonDown)
    {
        // Create the scan
        scan = Instantiate(scanPrefab, transform.position, Quaternion.identity) as ScanController;
		scan.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().sharedMaterial.color;

        // Can't scan twice
		canFire = false;

        // For each button down, set the proper target and let the scan know who made it
        switch (buttonDown)
        {
            case 'x':
                scan.SetTarget(0);
                scan.myPlayer = playerIndex;
                break;
            case 'y':
                scan.SetTarget(1);
                scan.myPlayer = playerIndex;
                break;
            case 'b':
                scan.SetTarget(2);
                scan.myPlayer = playerIndex;
                break;
            case 'a':
                scan.SetTarget(3);
                scan.myPlayer = playerIndex;
                break;
            default:
                break;
        }
        

    }

    void OnDestroy()
    {
        // When the level ends, destroy the current scan
        Destroy(scan.gameObject);
    }

}
