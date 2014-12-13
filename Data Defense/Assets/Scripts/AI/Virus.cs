using UnityEngine;
using System.Collections;

public class Virus : AIController {

	public AnimationCurve animationCurve;
	private const float Animation_Time = 0.4f;

	private const float Spawn_Time_Min = 3;
	private const float Spawn_Time_Max = 8;

	private float spawnTime = 0;

	protected void Start(){
		CalculateSpawnTime();
		base.Start();
	}

	protected void Update(){
		if(spawnTime <= Time.time){
			StartCoroutine(SpawnProgram());
		}
		base.Update();
	}

	private void CalculateSpawnTime(){
		spawnTime = Time.time + Random.Range(Spawn_Time_Min, Spawn_Time_Max);
	}

	private IEnumerator SpawnProgram(){
		CalculateSpawnTime();


		float animationStart = Time.time;
		while(animationStart + Animation_Time >= Time.time){
			transform.localScale = Vector3.one * animationCurve.Evaluate((Time.time - animationStart) / Animation_Time);
			yield return new WaitForEndOfFrame();
		}

		AISpawner.SpawnImmediately(FixedValues.Enemy_Types.Program, 1, transform);
		transform.localScale = Vector3.one;
	}
}
