using UnityEngine;
using System.Collections;

public class Data : AIController {

    protected bool corrupted;

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
            case FixedValues.Scans_Layer:
                ScanController scan = collision.gameObject.GetComponent<ScanController>();
                int scoreAmt = corrupted ? 1 : 3;
                FixedValues.playerScores[scan.myPlayer] += scoreAmt;
                FixedValues.superScanVals[scan.myPlayer] += scoreAmt;

                Destroy(gameObject);
                break;
            case FixedValues.Enemies_Layer:
                //Convert to corrupted here.
                gameObject.layer = FixedValues.CorruptedData_Layer;
                this.GetComponent<MeshRenderer>().material.color = Color.red;
                corrupted = true;
                break;
            case FixedValues.Lockdown_Layer:
                LockdownController lockdown = collision.gameObject.GetComponent<LockdownController>();
                int scoreAmtLockdown = corrupted ? 1 : 3;
                FixedValues.playerScores[lockdown.myPlayer] += scoreAmtLockdown;
                FixedValues.superScanVals[lockdown.myPlayer] += scoreAmtLockdown;
                Destroy(gameObject);
                break;
        }
    }
}
