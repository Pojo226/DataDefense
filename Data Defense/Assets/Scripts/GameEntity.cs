using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class GameEntity : MonoBehaviour {

    public float maxSpeed = 15;

    protected Vector3 movement;

    protected CharacterController charController;

	protected void Start(){
        charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	protected void Update(){
        movement.y = Physics.gravity.y;
        charController.Move(movement * maxSpeed * Time.deltaTime);
        movement = Vector3.zero;
	}
}
