using UnityEngine;
using System.Collections;

public class Data : AIController {

    // Call base start function
    protected override void Start(){
        base.Start();
    }

//    // When there's a collision, call base collision method
//    protected override void OnCollisionEnter(Collision collision)
//    {
//        Debug.Log("Hit by: " + collider.gameObject.layer);
//        base.OnCollisionEnter(collision);
//    }
}
