using UnityEngine;
using System.Collections;

public class LockdownController : MonoBehaviour {

    // Reference for players
    FixedValues fixedGO;

    // The player who initiated the lock
    public int myPlayer;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5.0f);
        fixedGO = GameObject.Find("Fixed Values").GetComponent<FixedValues>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnDestroy()
    {
        fixedGO.players[myPlayer].canLock = true;
    }
}
