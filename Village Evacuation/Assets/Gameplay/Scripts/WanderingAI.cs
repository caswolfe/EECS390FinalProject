using UnityEngine;
using System.Collections;

// Modified from ch07 unity package (originally for zombies)
public class WanderingAI : MonoBehaviour {
	public const float baseSpeed = 0.5f;

	public float speed;
	private GameObject playerObject;
	private bool _alive;
	private float _multiplier;
	// May need this later for animations
	/*
	void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	} */

	void Start() {
		_alive = true;
		
		playerObject = GameObject.Find("Player");
		speed = baseSpeed;

		Vector3 diff = playerObject.transform.position - transform.position;
		float range = diff.magnitude;
		
		if (range > 8.0f) {
			_multiplier = 0.0f;
		}
		if (range > 6.0f && range <= 8.0f) { 
			_multiplier = 3.0f;
		}
		if (range <= 6.0f) { 
			_multiplier = 8.0f;

		}

	}
	
	void LateUpdate() {
		if (_alive) {


			//if very far away zombie speed = 0: idle animation
			//if somewhat close zombie speed = walking speed: walking animation
			//if near zombie speed = 8.0*walking speed:running animation

			Vector3 diff = playerObject.transform.position - transform.position;
			float range = diff.magnitude;

			if (range > 7.0f) {
				_multiplier = 0.0f;
			}

	/*		if (range > 5.0f && range <= 7.0f) { 
				_multiplier = 1.0f;
			} */

			if (range <= 7.0f) { 
				_multiplier = 10.0f;
			}

			float largeVal = Mathf.Max(Mathf.Abs(diff.x), Mathf.Abs(diff.y));
			// This shouldn't be diff...this should be something directed towards diff...
			transform.Translate(diff.x / largeVal * Time.deltaTime * speed * _multiplier, diff.y / largeVal * Time.deltaTime * speed * _multiplier, 0, Space.World);

			Vector3 difference = playerObject.transform.position - transform.position;
			float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);

			//transform.LookAt(playerObject.transform);
			/*
						Ray ray = new Ray(transform.position, transform.forward);
						RaycastHit hit;
						if (Physics.SphereCast(ray, 0.75f, out hit)) {
							GameObject hitObject = hit.transform.gameObject;
							if (hitObject.GetComponent<PlayerCharacter>()) {
								Debug.log("Hit.");
							}
							else if (hit.distance < obstacleRange) {
								float angle = Random.Range(-110, 110);
								transform.Rotate(0, angle, 0);
							}
						}*/
		}
		else { Debug.Log("Dead.");  }
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}


}
