using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleVine : MonoBehaviour {

    private readonly static float GROWTH_SPEED = 0.03f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, (float)(gameObject.transform.localScale.z+GROWTH_SPEED));
		
	}
}
