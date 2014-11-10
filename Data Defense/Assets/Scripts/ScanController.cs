using UnityEngine;
using System.Collections;

public class ScanController : GameEntity {

    GameObject fixedGO;

    public int myPlayer;

    public Transform targetTransform;

	// Use this for initialization
	protected void Start () {
        fixedGO = GameObject.Find("Fixed Values");
        Destroy(gameObject, 1.5f);
        base.Start();

	}
	
	// Update is called once per frame
	protected void Update () {



        movement = targetTransform.position;
        
        base.Update();
        
	}

    public void setTarget(int playerIndex)
    {
        switch (playerIndex)
        {
            case 1:
                targetTransform = GameObject.Find("Player1").transform;
                break;
            case 2:
                targetTransform = GameObject.Find("Player2").transform;
                break;
            case 3:
                targetTransform = GameObject.Find("Player3").transform;
                break;
            case 4:
                targetTransform = GameObject.Find("Player4").transform;
                break;
            default:
                break;
        }
    }

    void OnDestroy()
    {
        print("Script was destroyed");

        switch (myPlayer)
        {
            case 1:
                fixedGO.GetComponent<FixedValues>().player1.canFire = true;
                break;
            case 2:
                fixedGO.GetComponent<FixedValues>().player2.canFire = true;
                break;
            case 3:
                fixedGO.GetComponent<FixedValues>().player3.canFire = true;
                break;
            case 4:
                fixedGO.GetComponent<FixedValues>().player4.canFire = true;
                break;
            default:
                break;
        }

        
    }

}
