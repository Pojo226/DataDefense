using UnityEngine;
using System.Collections;

public class AIController : GameEntity {

    protected Vector3 randomVector;

    protected float travelEndTime;
    protected float minTravelTime = 1;
    protected float maxTravelTime = 5;

	protected override void Start(){
	    base.Start();
        travelEndTime = Time.time;
	}
	
	protected void Update(){
        //Debug.Log(travelEndTime);
        if(travelEndTime <= Time.time){
            UpdateRandomMovementVector();
        }

        movement = randomVector;
        base.Update();
	}

    protected virtual void OnCollisionEnter(Collision collision)
    {
        UpdateRandomMovementVector(collision);
    }
    protected void UpdateRandomMovementVector(){
        randomVector = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        travelEndTime = Time.time + Random.Range(minTravelTime, maxTravelTime);
    }

    protected void UpdateRandomMovementVector(Collision collision){
        do{
            randomVector = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        }while(Vector3.Angle(randomVector, collision.contacts[0].point - transform.position) < 90);
        travelEndTime = Time.time + Random.Range(minTravelTime, maxTravelTime);
    }
}