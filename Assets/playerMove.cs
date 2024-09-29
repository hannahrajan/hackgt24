using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	public static bool canMove = true;
	[SerializeField] float _speed = 5.0f;
	[SerializeField] float _turnspeed = 0.1f;
	float turnSmoothVelocity;
	[SerializeField] float _gravity = 20.0f;
	[SerializeField] float _sensitivity = 5f;
	CharacterController _controller;
	float _horizontal, _vertical;
	//float _mouseX, _mouseY;

	// use this for initialization
	void Awake()
	{
		_controller = GetComponent<CharacterController>();
	}

	// screen drawing update - read inputs here
	void Update()
	{
		_horizontal = Input.GetAxis("Horizontal");
		_vertical = Input.GetAxis("Vertical");
		//_mouseX = Input.GetAxis("Mouse X");
		//_mouseY = Input.GetAxis("Mouse Y");
	}

	// physics simulation update - apply physics forces here
	void FixedUpdate()
	{
		Vector3 moveDirection = Vector3.zero;

		// is the controller on the ground?
		//if (_controller.isGrounded)
		//{
			// feed moveDirection with input.
			if (canMove)
			{
			moveDirection = new Vector3(_horizontal, 0, _vertical).normalized;

			if (moveDirection.magnitude >= 0.1f)
			{
				float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
				float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, _turnspeed);
				transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
				// multiply it by speed.
				moveDirection *= _speed;
				_controller.Move(moveDirection * Time.deltaTime);
				//Debug.Log(angle);
			}




			//}

			/*float turner = _mouseX * _sensitivity;
			if (turner != 0)
			{
				// action on mouse moving right
				transform.eulerAngles += new Vector3(0, turner, 0);
			}

			float looker = -_mouseY * _sensitivity;
			if (looker != 0)
			{
				// action on mouse moving right
				transform.eulerAngles += new Vector3(looker, 0, 0);
			}*/

			// apply gravity to the controller
			//moveDirection.y -= _gravity * Time.deltaTime;

			// make the character move
		}

	}

}
