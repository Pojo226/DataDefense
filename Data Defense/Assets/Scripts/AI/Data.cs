using UnityEngine;
using System.Collections;

public class Data : AIController {

    // Call base start function
    protected override void Start(){
        base.Start();
    }

    // When there's a collision, call base collision method
    protected override void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.layer){
            case 0: //Default/World
                UpdateRandomMovementVector(collision);
                break;
            case 10: //Scans
                ScanController scan = collision.gameObject.GetComponent<ScanController>();
                FixedValues.playerScores[scan.myPlayer] += 3;
                //FixedValues.superScanVals[scan.myPlayer] += 3;

                Destroy(gameObject);
                break;
            case 9:
                //Convert to corrupted here.
                //gameObject.layer = 9;
                break;
        }
    }
}
