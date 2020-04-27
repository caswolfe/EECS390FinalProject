using UnityEngine;
using System.Collections;

// Modified from ch07 unity package (originally for zombies)
public class WanderingAI : MonoBehaviour {
	public float baseSpeed;
	public float enemyRange = 1f;

	private float speed;
	private GameObject playerObject;
	private bool _alive;
	private float _multiplier;
	private bool paused;
	private PlayerController player;
	private Rigidbody2D rb;

	void Start() {
		_alive = true;
		paused = false;
		rb = GetComponent<Rigidbody2D>();
		
		playerObject = GameObject.Find("Player");
		speed = baseSpeed;

		Vector3 diff = playerObject.transform.position - transform.position;
		float range = diff.magnitude;
		
		if (range > 8.0f) {
			_multiplier = 0.0f;
		}
		if (range > 6.0f && range <= 8.0f) { 
			_multiplier = 1.0f;
		}
		if (range <= 6.0f) { 
			_multiplier = 2.0f;

		}

	}


	void LateUpdate() {
		Vector3 diff = playerObject.transform.position - transform.position;
		if (_alive && !paused) {

			//if very far away zombie speed = 0: idle animation
			//if somewhat close zombie speed = walking speed: walking animation
			//if near zombie speed = 8.0*walking speed:running animation


			float range = diff.magnitude;

			if (range > 5.0f) {
				_multiplier = 0.01f;
			}

			if (range > 5.0f && range <= 12.0f) { 
				_multiplier = 1.0f;
			}

			if (range <= 12.0f) { 
				_multiplier = 11.0f;
			}

			float largeVal = Mathf.Max(Mathf.Abs(diff.x), Mathf.Abs(diff.y));
			// This shouldn't be diff...this should be something directed towards diff...
			//transform.Translate(diff.x / largeVal * Time.deltaTime * speed * _multiplier, diff.y / largeVal * Time.deltaTime * speed * _multiplier, 0, Space.World);
			rb.AddForce(new Vector2(diff.x / largeVal * speed * _multiplier,
									diff.y / largeVal * speed * _multiplier),
						ForceMode2D.Force);

			Vector3 difference = playerObject.transform.position - transform.position;
			float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
		}
		if (paused && Vector3.Distance(playerObject.transform.position, transform.position) > 2f)
        {
			paused = false;
        }
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}

	IEnumerator Pause()
    {
		yield return new WaitForSeconds(1);
		paused = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Player")
        {
			playerObject.GetComponent<PlayerController>().takeDamage(10);

			paused = true;
			//StartCoroutine(Pause());
		}
	}

}
