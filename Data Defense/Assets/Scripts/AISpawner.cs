using UnityEngine;
using System.Collections;

public class AISpawner : MonoBehaviour {

    public float minSpawnTime;
    public float maxSpawnTime;

    public AIController[] enemies;

    public void StartSpawning(){
        for(int i = 0; i < enemies.Length; i++) {
            StartCoroutine(SpawnEnemies(enemies[i]));
        }
    }

    public void StopSpawning(){
        StopAllCoroutines();
    }

    private IEnumerator SpawnEnemies(AIController enemyType){
        while(true){
            //TODO: Make the position be random based on some world bounds?
            ((GameObject)GameObject.Instantiate(enemyType.gameObject, transform.position, Quaternion.identity)).transform.parent = transform;
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
}
