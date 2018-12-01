using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideZBounce : MonoBehaviour
{
    private readonly float EPSILON = 0.01f;
    public AudioSource metalSound;

    //private bool entered = false;
    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.StartsWith("ball"))
        {
            Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();

            //Debug.Log("z velocity working: " + ballRB.velocity.z);
            if (ballRB.velocity.z > 0)
            {
                ballRB.velocity = new Vector3(ballRB.velocity.x, ballRB.velocity.y, -ballRB.velocity.z);
            }
            else if(System.Math.Abs(ballRB.velocity.z) < EPSILON)
            {
                ballRB.velocity = new Vector3(ballRB.velocity.x, ballRB.velocity.y, -0.1f);
            }else if(other.tag == "bullet"){
            GameObject MetalImpact = (GameObject)Instantiate(Resources.Load("MetalImpact"));
            Vector3 bulletPos = other.transform.position;
            MetalImpact.transform.position = new Vector3(bulletPos.x,bulletPos.y,bulletPos.z);
            Destroy(other);
        }
        }
        else if (other.tag == "bullet")
        {
            GameObject MetalImpact = (GameObject)Instantiate(Resources.Load("MetalImpact"));
            Vector3 bulletPos = other.transform.position;
            MetalImpact.transform.position = new Vector3(bulletPos.x, bulletPos.y, bulletPos.z);
            Destroy(other.gameObject,0);
            metalSound.Play();
        }
    }

}
