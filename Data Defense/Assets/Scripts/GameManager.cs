using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public AISpawner AISpawner;

    // Start will configure the first spawn wave
	private void Start () {
        AISpawner.ConfigureNextSpawn(FixedValues.Enemy_Types.Data, 1);
        AISpawner.ConfigureNextSpawn(FixedValues.Enemy_Types.Program, 5);
        AISpawner.ConfigureNextSpawn(FixedValues.Enemy_Types.Virus, 7);
        AISpawner.SpawnWave();
	}
}