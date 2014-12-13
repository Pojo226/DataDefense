using UnityEngine;
using System.Collections;

public class Virus : AIController {

	private static float Spawn_Time_Min = 2;
	private static float Spawn_Time_Max = 5;

	private float spawnTime = 0;

	protected void Start(){
		CalculateSpawnTime();
		base.Start();
	}

	protected void Update(){
		if(spawnTime <= Time.time){
			CalculateSpawnTime();
			AISpawner.SpawnImmediately(FixedValues.Enemy_Types.Program, 1, transform);
		}
		base.Update();
	}

	private void CalculateSpawnTime(){
		spawnTime = Time.time + Random.Range(Spawn_Time_Min, Spawn_Time_Max);
		Debug.Log(spawnTime - Time.time);
	}
}
