using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NASA Space Apps Kodu Bu

public class NewBehaviourScript : MonoBehaviour {
	// Start is called before the first frame update

	void Start() {

	}

	// Update is called once per frame
	void Update() {

		if (Input.GetMouseButtonDown(0)) {
			Ray myRay = new Ray(transform.position, transform.forward);
			Debug.DrawLine(transform.position, transform.position + 10 * transform.forward, Color.magenta);
			//Debug.Log(transform.position + " " + transform.forward);
			RaycastHit objectHit;
			bool weHitSomething = Physics.Raycast(myRay, out objectHit);
			if (weHitSomething) { 
				Debug.Log(objectHit.transform.name);
				
			}
		}
	}
	private void PullPlayer() {
		
	}
}
