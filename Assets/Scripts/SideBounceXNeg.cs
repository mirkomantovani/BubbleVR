using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBounceXNeg : MonoBehaviour {

    // Use this for initialization
    private readonly float EPSILON = 0.01f;
    public AudioSource metalSound;

    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.StartsWith("ball"))
        {
            Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
            if (ballRB.velocity.x < 0)
            {
                ballRB.velocity = new Vector3(-ballRB.velocity.x, ballRB.velocity.y, ballRB.velocity.z);
            }
            else if (System.Math.Abs(ballRB.velocity.x) < EPSILON)
            {
                ballRB.velocity = new Vector3(0.1f, ballRB.velocity.y, ballRB.velocity.z);
            }

        } else if(other.tag == "bullet"){
            GameObject MetalImpact = (GameObject)Instantiate(Resources.Load("MetalImpact"));
            Vector3 bulletPos = other.transform.position;
            MetalImpact.transform.position = new Vector3(bulletPos.x,bulletPos.y,bulletPos.z);
            Destroy(other.gameObject,0);
            metalSound.Play();
        }
    }
}
