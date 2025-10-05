using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSystem : MonoBehaviour {
	public GameObject player;
	public PullPlayer pullPlayerScript;
	//public Rigidbody playerbody;
	public float maxRayDist = 5;
	//public float pullCoefficient = 0.3f;
	//public CharacterController cController;
	//private Vector3 direction;
	// Update is called once per frame
	void Update() {

		if (Input.GetMouseButton(0)) {
			Ray myRay = new Ray(transform.position, transform.forward);
			Debug.DrawLine(transform.position, transform.position + 10 * transform.forward, Color.magenta);
			//Debug.Log(transform.position + " " + transform.forward);
			RaycastHit objectHit;
			bool weHitSomething = Physics.Raycast(myRay, out objectHit, maxRayDist);
			if (weHitSomething) {
				Debug.Log(objectHit.transform.name);
				if (objectHit.transform.name == "HandleRayHitbox") {
					Debug.Log("handle'i vurduk");
					pullPlayerScript.pullPlayer(objectHit.transform);
				}
			}
		}
	}
	//private void pullPlayer(Transform transformHit) {
	//	direction = transformHit.position - player.transform.position;
	//	direction = (direction - new Vector3(1, 1, 1)) * pullCoefficient;
	//}
}
