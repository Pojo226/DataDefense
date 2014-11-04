using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GameEntity : MonoBehaviour {

    public float maxSpeed = 15;

    protected Vector3 movement;

    protected bool grounded = false;

    protected virtual void Awake() {
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
    }

    protected virtual void FixedUpdate(){
        Vector3 velocity = rigidbody.velocity;
        Vector3 velocityDelta = (movement - velocity);
        velocityDelta.x = Mathf.Clamp(velocityDelta.x, -maxSpeed, maxSpeed);
        velocityDelta.y = 0;
        rigidbody.AddForce(velocityDelta, ForceMode.VelocityChange);
        rigidbody.AddForce(new Vector3(0, Physics.gravity.y * rigidbody.mass, 0));

        movement = Vector3.zero;
    }
}