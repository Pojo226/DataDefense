using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class GameEntity : MonoBehaviour {

    // The max speed for any object to travel
    public float maxSpeed = 15;

    // Direction the object is moving
    protected Vector3 movement;

    // The object's own character controller
    protected CharacterController charController;

    // Set the character controller to it's own character controller
	virtual protected void Start(){
        charController = GetComponent<CharacterController>();
	}
	
    // Apply gravity and move the object in the specified direction
	protected void Update(){
        movement.y = Physics.gravity.y;
        charController.Move(movement * maxSpeed * Time.deltaTime);
        movement = Vector3.zero;
	}
}