using UnityEngine;

public class PullPlayer : MonoBehaviour
{
	public float moveSpeed = 0.3f;
	public Vector3 offset = new Vector3(1, 1, 1);
	private float sinTime;
	private Vector3 direction;
	private Vector3 start;
	private Vector3 target;
	private Transform lastHit;
	private GameObject handObject = null;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (lastHit == null) {
			Debug.Log("carpmadim");
			return;
		}
		if (lastHit != null && transform.position != lastHit.position) {
			sinTime += Time.deltaTime * moveSpeed;
			sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI);
			float t = evaluate(sinTime);
			transform.position = Vector3.Lerp(start, target, t);
		}
	}
	public void pullPlayer(Transform transformHit) {
		if (transformHit == lastHit) return;
		if (handObject != null) handObject.SetActive(false);
		handObject = transformHit.parent.Find("Hand").gameObject;
		handObject.SetActive(true);
		lastHit = transformHit;
		//GameObject hitObject = transformHit.gameObject;
		transformHit = transformHit.parent.Find("OffcenterObject");
		sinTime = 0f;
		direction = transformHit.position - transform.position;
		float newX, newY, newZ;
		newX = direction.x - offset.x * Mathf.Sign(direction.x);
		newY = direction.y - offset.y * Mathf.Sign(direction.y);
		newZ = direction.z - offset.z * Mathf.Sign(direction.z);
		direction.Set(newX, newY, newZ);
		target = direction + transform.position;
		start = transform.position;
		//direction = (direction - new Vector3(1, 1, 1)) * pullCoefficient;
	}
	private float evaluate(float x) {
		return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f;
	}
}
