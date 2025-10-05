using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController2: MonoBehaviour {
	public GameObject playerCamera;
	public float walkSpeed = 6f;
	public float runSpeed = 12f;
	public float jumpPower = 7f;
	public float gravity = 10f;
	public float crouchSpeed = 3f; // Add crouch speed
	public float crouchHeight = 0.5f; // Add crouch height

	public float lookSpeed = 2f;
	public float lookXLimit = 45f;

	Vector3 moveDirection = Vector3.zero;
	float rotationX = 0;

	public bool canMove = true;
	private bool isCrouching = false; // Add crouching flag

	CharacterController characterController;
	void Start() {
		characterController = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update() {
		#region Handles Movment
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 right = transform.TransformDirection(Vector3.right);

		// Press Left Shift to run
		bool isRunning = Input.GetKey(KeyCode.LeftShift);
		float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
		float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
		float movementDirectionY = moveDirection.y;

		// Handle crouching
		if (Input.GetKeyDown(KeyCode.C) && canMove) {
			isCrouching = !isCrouching;
			if (isCrouching) {
				characterController.height = crouchHeight;
			}
			else {
				characterController.height = 2f; // Reset to default height
			}
		}

		// Adjust speed if crouching
		if (isCrouching) {
			curSpeedX *= crouchSpeed;
			curSpeedY *= crouchSpeed;
		}

		moveDirection = (forward * curSpeedX) + (right * curSpeedY);

		#endregion

		#region Handles Jumping
		if (Input.GetButton("Jump") && canMove && characterController.isGrounded) {
			moveDirection.y = jumpPower;
		}
		else {
			moveDirection.y = movementDirectionY;
		}

		if (!characterController.isGrounded) {
			moveDirection.y -= gravity * Time.deltaTime;
		}

		#endregion

		#region Handles Rotation
		characterController.Move(moveDirection * Time.deltaTime);

		if (canMove) {
			rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
			rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
			playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
			transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
		}

		#endregion
	}
}