using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBounceY : MonoBehaviour
{

    // Use this for initialization

    private readonly float EPSILON = 0.01f;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.StartsWith("ball"))
        {
            Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
            if (ballRB.velocity.y < 0 | System.Math.Abs(ballRB.velocity.y) < EPSILON)
            {
                ballRB.velocity = new Vector3(ballRB.velocity.x, BallFactory.GetSpeedYFromGround(other.tag), ballRB.velocity.z);
            }

            //Debug.Log("z velocity new wall: " + ballRB.velocity.z);


        }
    }
}
