using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBounceZNeg : MonoBehaviour {

    // Use this for initialization
    private readonly float EPSILON = 0.01f;

    void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.StartsWith("ball"))
        {
            Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
            //Debug.Log("z velocity new wall: " + ballRB.velocity.z);
            if (ballRB.velocity.z < 0)
            {
                ballRB.velocity = new Vector3(ballRB.velocity.x, ballRB.velocity.y, -ballRB.velocity.z);
            }
            else if (System.Math.Abs(ballRB.velocity.z) < EPSILON)
            {
                ballRB.velocity = new Vector3(ballRB.velocity.x, ballRB.velocity.y, 0.1f);
            }

            //Debug.Log("z velocity new wall: " + ballRB.velocity.z);


        }
    }
}
