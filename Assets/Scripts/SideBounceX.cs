using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBounceX : MonoBehaviour {

    // Use this for initialization

    private readonly float EPSILON = 0.01f;

    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.StartsWith("ball"))
        {
            Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
            if (ballRB.velocity.x > 0)
            {
                ballRB.velocity = new Vector3(-ballRB.velocity.x, ballRB.velocity.y, ballRB.velocity.z);
            }
            else if (System.Math.Abs(ballRB.velocity.x) < EPSILON)
            {
                ballRB.velocity = new Vector3(-0.1f, ballRB.velocity.y, ballRB.velocity.z);
            }

            //Debug.Log("z velocity new wall: " + ballRB.velocity.z);


        }
    }
}
