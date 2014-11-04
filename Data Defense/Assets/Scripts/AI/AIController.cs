using UnityEngine;
using System.Collections;

public class AIController : GameEntity {

    public float speed = 10;
    
    protected Vector3 randomVector;

    protected float travelEndTime;
    protected float minTravelTime = 1;
    protected float maxTravelTime = 5;

	protected override void Awake(){
	    base.Awake();
        travelEndTime = Time.time;
	}
	
	protected void FixedUpdate(){
        if(travelEndTime <= Time.time){
            UpdateRandomMovementVector();
        }
        movement = randomVector;
        base.FixedUpdate();
	}

    protected void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger: " + gameObject.name);
        UpdateRandomMovementVector();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision: " + gameObject.name);
        UpdateRandomMovementVector(collision);
    }
    protected void UpdateRandomMovementVector(){
        randomVector = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        randomVector *= speed;
        travelEndTime = Time.time + Random.Range(minTravelTime, maxTravelTime);
    }

    protected void UpdateRandomMovementVector(Collision collision){
        do{
            randomVector = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            randomVector *= speed;
        }while(Vector3.Angle(randomVector, collision.contacts[0].point - transform.position) < 90);
        travelEndTime = Time.time + Random.Range(minTravelTime, maxTravelTime);
    }
}