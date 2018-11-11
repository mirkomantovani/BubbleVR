using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleVine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, (float)(gameObject.transform.localScale.z+0.02));
		
	}
}
