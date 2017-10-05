using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

	public int bulletSpeed;
	public int secondsToSelfDestruct = 5;

	void Start () {

		// Get it moving
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * bulletSpeed;

		// Start self destruct coroutine
		StartCoroutine(destroySelf());
	}

	IEnumerator destroySelf() {
		yield return new WaitForSeconds(secondsToSelfDestruct);
		Destroy(this.gameObject);
	}
}
