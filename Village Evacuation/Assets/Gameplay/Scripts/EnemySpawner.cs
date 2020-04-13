using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;

	public int toSpawn = 10;

	void Start()
	{
		int spawned = 0;
		while (spawned < toSpawn)
		{
			// Spawn enemy at random X, Z location around the map
			Vector3 randLoc = new Vector3(Random.Range(0, 60.0f), -5, 10);
			// Check that the spawn point is "free" by using a sphere radius 1 @ loc
			Collider[] checkResult = Physics.OverlapSphere(randLoc, 1);
			if (checkResult.Length == 0)
			{
				//randLoc.y = -5f;
				_enemy = Instantiate(enemyPrefab) as GameObject;
				_enemy.transform.position = randLoc;
				float angle = Random.Range(0, 360);
				_enemy.transform.Rotate(0, angle, 0);
				_enemy.GetComponent<WanderingAI>().SetAlive(true);
				spawned += 1;
			}
		}
	}
}
