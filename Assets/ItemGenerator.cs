using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject carPrefab;

	public GameObject coinPrefab;

	public GameObject conePrefab;

	private GameObject unitychan;

	private float unityPosZ = 0;

	private int startPos = -160;

	private int goalPos = 120;

	private int generateDis = 45;

	private int nextGeneratePos = 0;

	private float posRange = 3.4f;
	// Use this for initialization
	void Start () {
		unitychan = GameObject.Find ("unitychan");

		nextGeneratePos = startPos;
	}
	
	// Update is called once per frame
	void Update () {
		unityPosZ = unitychan.transform.position.z;

		if ((startPos <= unityPosZ + generateDis) && (unityPosZ + generateDis < goalPos)) {
			if (nextGeneratePos < unityPosZ + generateDis) {
				int num = Random.Range (0, 10);
				if (num <= 1) {
					for (float j = -1; j <= 1; j += 0.4f) {
						GameObject cone = Instantiate (conePrefab) as GameObject;
						cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, nextGeneratePos);
					}
				} else {
					for (int j = -1; j < 2; j++) {
						int item = Random.Range (1, 11);

						int offsetZ = Random.Range (-5, 6);

						if (1 <= item && item <= 6) {
							GameObject coin = Instantiate (coinPrefab) as GameObject;
							coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, nextGeneratePos + offsetZ);
						} else if (7 <= item && item <= 9) {
							GameObject car = Instantiate (carPrefab) as GameObject;
							car.transform.position = new Vector3 (posRange * j, car.transform.position.y, nextGeneratePos + offsetZ);
						}
					}
				}

				nextGeneratePos += 15;
			}
		}
	}
}
