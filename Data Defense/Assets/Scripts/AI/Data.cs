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
        if(collision.gameObject.layer != 0){ //If collision isn't with default/world
            ScanController scan = collision.gameObject.GetComponent<ScanController>();
            FixedValues.playerScores[scan.myPlayer] += 3;
            //FixedValues.superScanVals[scan.myPlayer] += 3;

            Destroy(gameObject);
        }
        UpdateRandomMovementVector(collision);
    }
}
