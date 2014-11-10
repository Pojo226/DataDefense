using UnityEngine;
using System.Collections;

public class ScanController : GameEntity {

    // Reference for players
    GameObject fixedGO;

    // The player who initiated the scan
    public int myPlayer;

    // The target player's transform
    public Transform targetTransform;

	// Use this for initialization
	protected void Start () {
        // Initialize the FixedGO. Also, set up a time limit for the scan since we don't have collision detection yet
        fixedGO = GameObject.Find("Fixed Values");
        Destroy(gameObject, 1.5f);
        base.Start();

	}
	
	// Update is called once per frame
	protected void Update () {

        // Set the movement towards the target player using subtraction and vector normalization
        movement = new Vector3(targetTransform.position.x - transform.position.x, 0, targetTransform.position.z - transform.position.z);
        movement = Vector3.Normalize(movement);
        
        base.Update();
        
	}

    public void SetTarget(int playerIndex)
    {
        // We can use GameObject.Find because we are not doing this every frame.
        switch (playerIndex)
        {
            case 1:
                targetTransform = GameObject.Find("Player1").transform;
                break;
            case 2:
                targetTransform = GameObject.Find("Player2").transform;
                break;
            case 3:
                targetTransform = GameObject.Find("Player3").transform;
                break;
            case 4:
                targetTransform = GameObject.Find("Player4").transform;
                break;
            default:
                break;
        }
    }

    void OnDestroy()
    {
        print("Script was destroyed");

        switch (myPlayer)
        {
                // when the scan is done, the player may now initialize another scan. In each case, make sure the fixedGO exists.
            case 1:
                if (fixedGO != null)
                    fixedGO.GetComponent<FixedValues>().player1.canFire = true;
                break;
            case 2:
                if (fixedGO != null)
                    fixedGO.GetComponent<FixedValues>().player2.canFire = true;
                break;
            case 3:
                if (fixedGO != null)
                    fixedGO.GetComponent<FixedValues>().player3.canFire = true;
                break;
            case 4:
                if (fixedGO != null)
                    fixedGO.GetComponent<FixedValues>().player4.canFire = true;
                break;
            default:
                break;
        }

        
    }

}
