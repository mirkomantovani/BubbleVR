using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopBall : MonoBehaviour {

    public GameObject ball2;
    public Animator popAnim;
    public AudioSource popSound;

    private const int ScoreIncrementOnPop = 1;

    private float acceleration = 9.8067f;

    private bool hit = false;

	// Use this for initialization
	void Start () {
		
	}

    //Colliding with bullet
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (!hit & other.tag == "bullet")
        {
            //Debug.Log(other.name+ " hit ball");
            Rigidbody rigidBullet = other.gameObject.GetComponent<Rigidbody>();
            ScoreText.IncrementScore(ScoreIncrementOnPop);
            //Debug.Log("bullVelX " + rigidBullet.velocity.x);
            //Debug.Log("bullVelY " + rigidBullet.velocity.y);
            //Debug.Log("bullVelZ " + rigidBullet.velocity.z);

            //Destroy(other.gameObject);
            Divide(other.gameObject.GetComponent<Info>());
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject,0);
            hit = true;
        } else if(other.name.StartsWith("[VRTK][AUTOGEN]") & GameManager.CanDie()){
            GameManager.GameOver();
            Invoke("RestartScene", 3);
        }
    }

    private void RestartScene()
    {
        RestartGame.RestartScene();
    }

    private void Divide(Info bulletInfo)
    {
        //float bullVelX = bulletTrans.velocity.x;
        //float bullVelZ = bulletTrans.velocity.z;

        float bullVelX = bulletInfo.getX();
        float bullVelZ = bulletInfo.getZ();

        float norm = (float)Math.Sqrt(bullVelX * bullVelX + bullVelZ * bullVelZ);

        //Debug.Log("bullVelX " + bullVelX);
        //Debug.Log("bullVelZ " + bullVelZ);
        bullVelZ = bullVelZ * 5;
        bullVelX = bullVelX * 5;
        //Debug.Log("Divide");
        //Debug.Log("bullVelX " + bullVelX);
        //Debug.Log("bullVelZ " + bullVelZ);

        Transform trans = gameObject.transform;
        DestroyBall(gameObject);
        float velY = ComputeInitialYVelocity(trans.position.y);
        if(velY != velY)
        {
            velY = 5.0f;
        }
            

        trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.z);
        GameObject newBall = (GameObject)Instantiate(ball2, trans.position, trans.rotation);
        BallManager.AddBall(newBall);
        newBall.GetComponent<Rigidbody>().velocity = new Vector3(-bullVelZ, velY, bullVelX);

        newBall.GetComponent<AudioSource>().Play();

        trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.z);
        GameObject newBall2 = (GameObject)Instantiate(ball2, trans.position, trans.rotation);
        BallManager.AddBall(newBall2);
        newBall2.GetComponent<Rigidbody>().velocity = new Vector3(bullVelZ, velY, -bullVelX);
    }

    //divide due to effect of bomb
    public void Divide()
    {

        float bullVelX = 0.1f;
        float bullVelZ = 0.1f;

        float norm = (float)Math.Sqrt(bullVelX * bullVelX + bullVelZ * bullVelZ);

        bullVelZ = bullVelZ * 5;
        bullVelX = bullVelX * 5;

        Transform trans = gameObject.transform;
        DestroyBall(gameObject);
        float velY = ComputeInitialYVelocity(trans.position.y);
        //Debug.Log(velY);

        trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.z);
        GameObject newBall = (GameObject)Instantiate(ball2, trans.position, trans.rotation);
        BallManager.AddBall(newBall);
        newBall.GetComponent<Rigidbody>().velocity = new Vector3(-bullVelZ, 0, bullVelX);

        newBall.GetComponent<AudioSource>().Play();

        trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.z);
        GameObject newBall2 = (GameObject)Instantiate(ball2, trans.position, trans.rotation);
        BallManager.AddBall(newBall2);
        newBall2.GetComponent<Rigidbody>().velocity = new Vector3(bullVelZ, 0, -bullVelX);
    }

    private float ComputeInitialYVelocity(float posY){
        //velY = sqrt((wantedHeight - initialPosY)*2*g)
        float targetHeight = BallFactory.GetPoppedBallTargetHeight(gameObject.tag);

        return (float)Math.Sqrt((targetHeight - posY) * 2 * acceleration);
        

    }

    private void DestroyBall(GameObject ball)
    {
        ball.GetComponent<Collider>().enabled = false;
        //Invoke("deactivateBall", 2);
        BallManager.RemoveBall(ball);
        Destroy(ball);
      
        //popAnim.Play("PopBall");
    }


    // Update is called once per frame
    void Update () {
		
	}
}
