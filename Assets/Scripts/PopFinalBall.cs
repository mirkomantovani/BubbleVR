using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopFinalBall : MonoBehaviour {


    private float acceleration = 9.8067f;
    private const int ScoreIncrementOnPop = 2;
    public AudioSource popSound;

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
            ScoreText.IncrementScore(ScoreIncrementOnPop);

            //other.gameObject.SetActive(false);
            Destroy(other.gameObject, 0);
            hit = true;
            DestroyBall(gameObject);
        } else if(other.name.StartsWith("[VRTK][AUTOGEN]") & GameManager.CanDie())
        {
            GameManager.GameOver();
            Invoke("RestartScene", 3);
        }
    }

    private void RestartScene()
    {
        RestartGame.RestartScene();
    }

    private void DestroyBall(GameObject ball)
    {
        popSound.Play();
        ball.GetComponent<MeshRenderer>().enabled = false;
        ball.GetComponent<Collider>().enabled = false;
        BallManager.RemoveBall(ball);
        Destroy(ball, 1);
    }

    public void DestroySelf(){
        DestroyBall(gameObject);
    }

}
