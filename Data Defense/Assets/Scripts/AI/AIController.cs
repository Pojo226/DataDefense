using UnityEngine;
using System.Collections;

public class AIController : GameEntity {

    // Update this vector when assigning new direction for entity
    protected Vector3 randomVector;

    // Floats for time before the entity changes direction
    protected float travelEndTime;
    protected float minTravelTime = 1;
    protected float maxTravelTime = 5;

    // Call parent Start() and initialize the start time 
    // (This will fail in the first call to Update())
	protected override void Start()
    {
	    base.Start();
        travelEndTime = Time.time;
	}
	
    // Check if the object has been travelling in the same 
    // direction to long and change direction if necessary
	protected void Update()
    {
        //Debug.Log(travelEndTime);
        if(travelEndTime <= Time.time)
        {
            UpdateRandomMovementVector();
        }

        movement = randomVector;
        base.Update();
	}

    // When there's a collision, change the direction
    protected virtual void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.layer){
            case 0: //World/Terrain
                UpdateRandomMovementVector(collision);
                break;
            case FixedValues.Scans_Layer:
                ScanController scan = collision.gameObject.GetComponent<ScanController>();

                FixedValues.playerScores[scan.myPlayer]++;
                FixedValues.superScanVals[scan.myPlayer]++;
                FixedValues.enemyNum--;
                AISpawner.SpawnImmediately(FixedValues.Enemy_Types.Data, 3, transform);
                Destroy(gameObject);

			    if(!scan.superScan){
                    Destroy(collision.gameObject);
			    }
                break;

        }
    }

    // Change the direction
    protected void UpdateRandomMovementVector()
    {
        randomVector = Vector3.Normalize(new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)));
        travelEndTime = Time.time + Random.Range(minTravelTime, maxTravelTime);
    }

    // Change the direction with collision in mind
    protected void UpdateRandomMovementVector(Collision collision){
		Vector3 collisionDir = transform.position - collision.contacts[0].point;
		RaycastHit hit;
		if(Physics.Raycast(transform.position, collision.contacts[0].point - transform.position, out hit, Mathf.Infinity, 1 << 0)){
			collisionDir = hit.normal;
		}

        do{
            randomVector = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        }while(Vector3.Angle(randomVector, collisionDir) > 80);
        
		randomVector = Vector3.Normalize(randomVector);
        travelEndTime = Time.time + Random.Range(minTravelTime, maxTravelTime);
    }
}