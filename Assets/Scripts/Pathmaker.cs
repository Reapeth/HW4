using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathmaker : MonoBehaviour {
	public static int globalCounter;
	public int counter;
	public Transform spikedFloorPrefab;
	public Transform hallFloorPrefab;
	public Transform normalFloorPrefab;
	public Transform pathmakerSpherePrefab;
	private float randomTurnChance;
	private float pathmakerSpawnChance;
	void Start () {
		if (Time.timeSinceLevelLoad == 0) {
			globalCounter = 0;
		}
		randomTurnChance = Random.Range (0.1f, 0.3f);
		pathmakerSpawnChance = Random.Range (0.01f, 0.1f);
	}
	void Update () {
		counter = globalCounter;
		if (globalCounter < 500) {
			float randFloat = Random.Range (0f, 1f);
			if (randFloat < randomTurnChance) {
				transform.Rotate (new Vector3 (0f, 90f, 0f));
			} else if (randFloat >= randomTurnChance && randFloat < (randomTurnChance * 2)) {
				transform.Rotate (new Vector3 (0f, -90f, 0f));
			} else if (randFloat >= (1f - pathmakerSpawnChance) && randFloat <= 1f) {
				Instantiate (pathmakerSpherePrefab, transform.position, Quaternion.identity);
			}
			if (randomTurnChance >= 0.1f && randomTurnChance < 0.2f) {
				float randHallFloat = Random.Range (0f, 1f);
				if (randHallFloat < 0.7f) {
					Instantiate (hallFloorPrefab, transform.position, transform.rotation);
				} else if (randHallFloat >= 0.7f && randHallFloat <= 1f) {
					Instantiate (normalFloorPrefab, transform.position, Quaternion.identity);
				}
			} else if (randomTurnChance >= 0.2f && randomTurnChance <= 0.3f) {
				float randRoomFloat = Random.Range (0f, 1f);
				if (randRoomFloat < 0.8f) {
					Instantiate (normalFloorPrefab, transform.position, Quaternion.identity);
				} else if (randRoomFloat >= 0.8f && randRoomFloat <= 1f) {
					Instantiate (spikedFloorPrefab, transform.position, Quaternion.identity);
				}
			}
			transform.Translate (Vector3.forward * 5f);
			globalCounter++;
		} else {
			Destroy (gameObject);
		}
	}
}
