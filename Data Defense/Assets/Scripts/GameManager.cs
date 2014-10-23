using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public AISpawner AISpawner;

	private void Start () {
        AISpawner.ConfigureNextSpawn(FixedValues.Enemy_Types.Data, 1);
        AISpawner.ConfigureNextSpawn(FixedValues.Enemy_Types.Program, 1);
        AISpawner.ConfigureNextSpawn(FixedValues.Enemy_Types.Virus, 1);
        AISpawner.SpawnWave();
	}
}