using UnityEngine;
using System.Collections;

public class AIController : GameEntity {

    protected Vector3 randomVector;

    protected float travelEndTime;
    protected float minTravelTime = 1;
    protected float maxTravelTime = 5;

	protected void Start(){
	    base.Start();
        travelEndTime = Time.time;
	}
	
	protected void Update(){
        if(travelEndTime <= Time.time){
            randomVector = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            travelEndTime = Time.time + Random.Range(minTravelTime, maxTravelTime);
            Debug.Log(randomVector.x + "\t" + randomVector.z);
            Debug.Log(travelEndTime);
        }

        movement = randomVector;
        base.Update();
	}
}
