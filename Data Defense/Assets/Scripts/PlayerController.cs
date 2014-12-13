using UnityEngine;
using System.Collections;

public class PlayerController : GameEntity {

    // The player's scan
    public ScanController scanPrefab;
    public ScanController scan;
    public bool canFire;
	public bool hasSuper;

    // Effectively, the players identification number
    public int playerIndex;

    // The player's Lockdown
    public LockdownController lockdownPrefab;
    public LockdownController lockdown;
    public bool canLock;

    // Call the base start method
	protected void Start(){
        canFire = true;
        canLock = true;
        base.Start();
	}
	

	// Update is called once per frame
	protected void Update(){

		//check if the player can use a super scan
		if (FixedValues.superScanVals[playerIndex] >= FixedValues.superScanCost) {
			hasSuper = true;
		}
		else {
			hasSuper = false;
		}

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
			if (hasSuper == true && playerIndex != 0 && canFire == true  && canLock == true && (Input.GetButton("RB_" + (playerIndex + 1)) || Input.GetButton("LB_" + (playerIndex + 1)))){
				SetSuperScan('x');
			}
            else if (playerIndex != 0 && canFire == true && canLock == true)
            {
				SetScan('x');
			}
            else if (playerIndex == 0 && canLock == true)
            {
                // If you're the pressing your own color, Lockdown!
                SetLock();
            }
		}
		
		if (Input.GetButtonDown("Y_" + (playerIndex + 1)))
		{
            if (hasSuper == true && playerIndex != 1 && canFire == true && canLock == true && (Input.GetButton("RB_" + (playerIndex + 1)) || Input.GetButton("LB_" + (playerIndex + 1))))
            {
				SetSuperScan('y');
			}
            else if (playerIndex != 1 && canFire == true && canLock == true)
            {
				SetScan('y');
			}
            else if (playerIndex == 1 && canLock == true)
            {
                // If you're the pressing your own color, Lockdown!
                SetLock();
            }
		}
		
		if (Input.GetButtonDown("B_" + (playerIndex + 1)))
		{
            if (hasSuper == true && playerIndex != 2 && canFire == true && canLock == true && (Input.GetButton("RB_" + (playerIndex + 1)) || Input.GetButton("LB_" + (playerIndex + 1))))
            {
				SetSuperScan('b');
			}
            else if (playerIndex != 2 && canFire == true && canLock == true)
            {
				SetScan('b');
			}
            else if (playerIndex == 2 && canLock == true)
            {
                // If you're the pressing your own color, Lockdown!
                SetLock();
            }
		}
		
		if (Input.GetButtonDown("A_" + (playerIndex + 1)))
		{
            if (hasSuper == true && playerIndex != 3 && canFire == true && canLock == true && (Input.GetButton("RB_" + (playerIndex + 1)) || Input.GetButton("LB_" + (playerIndex + 1))))
            {
				SetSuperScan('a');
			}
            else if (playerIndex != 3 && canFire == true && canLock == true)
            {
				SetScan('a');
			}
            else if (playerIndex == 3 && canLock == true)
            {
                // If you're the pressing your own color, Lockdown!
                SetLock();
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
	
	void SetSuperScan(char buttonDown)
	{
		// Create the scan
		scan = Instantiate(scanPrefab, transform.position, Quaternion.identity) as ScanController;
		
		// Can't scan twice
		canFire = false;
		
		// Reset the Super Scan Value
		FixedValues.superScanVals [playerIndex] = 0.0f;
		
		// For each button down, set the proper target and let the scan know who made it
		switch (buttonDown)
		{
		case 'x':
			scan.SetTarget(0);
			scan.myPlayer = playerIndex;
			scan.superScan = true;
			break;
		case 'y':
			scan.SetTarget(1);
			scan.myPlayer = playerIndex;
			scan.superScan = true;
			break;
		case 'b':
			scan.SetTarget(2);
			scan.myPlayer = playerIndex;
			scan.superScan = true;
			break;
		case 'a':
			scan.SetTarget(3);
			scan.myPlayer = playerIndex;
			scan.superScan = true;
			break;
		default:
			break;
		}
	}
    void SetLock()
    {
        // Create the lock
        lockdown = Instantiate(lockdownPrefab, transform.position, Quaternion.identity) as LockdownController;
        lockdown.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().sharedMaterial.color;

        // Can't lock twice
        canLock = false;


        lockdown.transform.position = new Vector3(lockdown.transform.position.x, lockdown.transform.position.y + 0.1f, lockdown.transform.position.z);

        lockdown.myPlayer = playerIndex;
    }
}
