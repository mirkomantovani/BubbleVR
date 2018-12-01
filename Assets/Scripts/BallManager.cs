using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    //private GameObject[] balls;
    private static List<GameObject> balls = new List<GameObject>();

    // Use this for initialization
    void Start () {
        //balls = new List<GameObject>();

    }

    public static void ResetBallList()
    {

        balls = new List<GameObject>();
    }

    public static void RemoveBall(GameObject ball)
    {

        balls.Remove(ball);
    }

    public static void AddBall(GameObject ball){
        IgnoreCollisionAllBalls(ball);

        balls.Add(ball);
    }


    internal static void StopBalls()
    {
        foreach (var b in balls)
        {
            b.GetComponent<Rigidbody>().isKinematic = true;
            b.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    internal static void ExplodeBalls()
    {
        foreach (var b in balls.ToArray())
        {
            if(b.tag == "ball2"){
                RemoveBall(b);
                b.GetComponent<PopFinalBall>().DestroySelf();
            } else{
                RemoveBall(b);
                b.GetComponent<PopBall>().Divide();
            }
        }
    }

    private static void IgnoreCollisionAllBalls(GameObject ball)
    {
        foreach(var b in balls)
        {
            if (b == null)
                Debug.Log("b null in ball manager");
            if (ball == null)
                Debug.Log("ball null in ball manager");
            Physics.IgnoreCollision(b.GetComponent<Collider>(), ball.GetComponent<Collider>());
            //Console.WriteLine(item);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
