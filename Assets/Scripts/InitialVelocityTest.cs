using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocityTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
