using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopFinalBall : MonoBehaviour {

    public Animator popAnim;
    public AudioSource popSound;


    private float acceleration = 9.8067f;

    private bool hit = false;

    // Use this for initialization
    void Start()
    {

    }

    //Colliding with bullet
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collider ball something entered");
        if (!hit & other.tag == "bullet")
        {
            Rigidbody rigidBullet = other.gameObject.GetComponent<Rigidbody>();

            //Divide(other.gameObject.GetComponent<Info>());
            other.gameObject.SetActive(false);
            Destroy(other.gameObject, 1);
            hit = true;
        }
    }

    //private void Divide(Info bulletInfo)
    //{
    //    //float bullVelX = bulletTrans.velocity.x;
    //    //float bullVelZ = bulletTrans.velocity.z;

    //    float bullVelX = bulletInfo.getX();
    //    float bullVelZ = bulletInfo.getZ();

    //    float norm = (float)Math.Sqrt(bullVelX * bullVelX + bullVelZ * bullVelZ);

    //    //Debug.Log("bullVelX " + bullVelX);
    //    //Debug.Log("bullVelZ " + bullVelZ);
    //    bullVelZ = bullVelZ * 5;
    //    bullVelX = bullVelX * 5;
    //    //Debug.Log("Divide");
    //    //Debug.Log("bullVelX " + bullVelX);
    //    //Debug.Log("bullVelZ " + bullVelZ);

    //    Transform trans = gameObject.transform;
    //    DestroyBall(gameObject);


    //}


    private void DestroyBall(GameObject ball)
    {
        ball.GetComponent<Collider>().enabled = false;
        BallManager.RemoveBall(ball);
        Destroy(ball, 2);
        popSound.Play();
        popAnim.Play("PopBall2");
    }




    // Update is called once per frame
    void Update()
    {

    }
}
