using UnityEngine;
using System.Collections;

public class Data : AIController {

    protected override void Start(){
        base.Start();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit by: " + collider.gameObject.layer);
        base.OnCollisionEnter(collision);
    }
}
