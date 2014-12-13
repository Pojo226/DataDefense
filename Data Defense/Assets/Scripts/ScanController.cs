using UnityEngine;
using System.Collections;

public class ScanController : GameEntity {

    // Reference for players
    FixedValues fixedGO;

    // The player who initiated the scan
    public int myPlayer;

    // The target player's transform
	public Transform targetTransform;
	
	//bool for whether or not scan is a Super Scan
	public bool superScan;

	// Use this for initialization
	protected void Start(){
        base.Start();
	}
	
	// Update is called once per frame
	protected void Update(){

        // Set the movement towards the target player using subtraction and vector normalization
        movement = new Vector3(targetTransform.position.x - transform.position.x, 0, targetTransform.position.z - transform.position.z);
        movement = Vector3.Normalize(movement);

		if(superScan){
			movement *= 5;
		}
        
        base.Update();
        
	}

    public void SetTarget(int playerIndex){
        // Initialize the FixedGO. Also, set up a time limit for the scan since we don't have collision detection yet
        fixedGO = GameObject.Find("Fixed Values").GetComponent<FixedValues>();
        Destroy(gameObject, 2.0f);

        // We can use GameObject.Find because we are not doing this every frame.
		targetTransform = fixedGO.players[playerIndex].transform;
	}
	
	void OnDestroy(){
		fixedGO.players[myPlayer].canFire = true;
    }
}
