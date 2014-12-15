using UnityEngine;
using System.Collections;

public class LockdownController : MonoBehaviour {

    // Reference for players
    FixedValues fixedGO;

    // The player who initiated the lock
    public int myPlayer;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2.0f);
        fixedGO = GameObject.Find("Fixed Values").GetComponent<FixedValues>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(fixedGO.players[myPlayer].transform.position.x, transform.position.y, fixedGO.players[myPlayer].transform.position.z);
	}

    void OnDestroy()
    {
        fixedGO.players[myPlayer].canLock = true;
    }
}
