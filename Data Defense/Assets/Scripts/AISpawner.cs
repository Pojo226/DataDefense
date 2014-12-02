using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISpawner : MonoBehaviour {

	private static AISpawner instance;

    // Array that contains enemies to spawn
    public AIController[] enemies;

    // Array to state how many of each enemy to spawn
    private int[] spawnWaves;

    // Initialize the spawnwaves array to the length of unique enemies
    private void Start(){
		instance = this;
        spawnWaves = new int[enemies.Length];
    }

    // Get ready to spawn the next wave by declaring how many of each enemy to spawn
    public void ConfigureNextSpawn(FixedValues.Enemy_Types enemyType, int numToSpawn){
        spawnWaves[(int)enemyType] = numToSpawn;
    }

    // Spawn the enemies into the game
    public void SpawnWave(){
        // For every enemy type
        for(int i = 0; i < spawnWaves.Length; i++){
            // Create the number of enemies specified in the array
            for(int j = 0; j < spawnWaves[i]; j++){
                ((GameObject)GameObject.Instantiate(enemies[i].gameObject, transform.position, Quaternion.identity)).transform.parent = transform;

				//add to enemyNum if enemy is on screen
				if( !spawnWaves[i].Equals(FixedValues.Enemy_Types.Data))
				{
					FixedValues.enemyNum++;
				}
            }
        }
    }



	public static void SpawnImmediately(FixedValues.Enemy_Types enemyType, int numToSpawn, Transform spawnLocation){
		instance.SpawnImmediatelyInternal(enemyType, numToSpawn, spawnLocation);
	}

	private void SpawnImmediatelyInternal(FixedValues.Enemy_Types enemyType, int numToSpawn, Transform spawnLocation){
		for(int i = 0; i < numToSpawn; i++){
			((GameObject)GameObject.Instantiate(enemies[(int)enemyType].gameObject, spawnLocation.position, Quaternion.identity)).transform.parent = transform;
		}

		if(!enemyType.Equals(FixedValues.Enemy_Types.Data)){
			//FixedValues.enemyNum += numToSpawn;
		}
	}
}