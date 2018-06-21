using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour {

	private GameObject unitychan;

	private float difference;
	// Use this for initialization
	void Start () {
		unitychan = GameObject.Find ("unitychan");

		difference = this.unitychan.transform.position.z - this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.unitychan.transform.position.z - difference);
//		GetComponent<Rigidbody>().AddForce(0,0,1);
	}

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
	}
}
