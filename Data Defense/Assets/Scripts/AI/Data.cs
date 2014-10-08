using UnityEngine;
using System.Collections;

public class Data : AIController {

    protected override void Start(){
        base.Start();
    }

    protected override void OnTriggerEnter(Collider collider){
        Debug.Log("Hit by: " + collider.gameObject.layer);
        base.OnTriggerEnter(collider);
    }
}
