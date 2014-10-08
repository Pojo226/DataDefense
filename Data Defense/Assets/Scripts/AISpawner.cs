using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISpawner : MonoBehaviour {

    public AIController[] enemies;
    private int[] spawnWaves;

    private void Start(){
        spawnWaves = new int[enemies.Length];
    }

    public void ConfigureNextSpawn(FixedValues.Enemy_Types enemyType, int numToSpawn){
        spawnWaves[(int)enemyType] = numToSpawn;
    }

    public void SpawnWave(){
        for(int i = 0; i < spawnWaves.Length; i++){
            for(int j = 0; j < spawnWaves[i]; j++){
                ((GameObject)GameObject.Instantiate(enemies[i].gameObject, transform.position, Quaternion.identity)).transform.parent = transform;
            }
        }
    }
}