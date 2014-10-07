using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public AISpawner AISpawner;

	private void Start () {
        AISpawner.StartSpawning();
	}
}
