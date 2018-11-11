using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager{

    //private GameObject[] balls;
    private static List<GameObject> balls = new List<GameObject>();

    // Use this for initialization
    void Start () {
        
		
	}

    public static void RemoveBall(GameObject ball)
    {

        balls.Remove(ball);
    }

    public static void AddBall(GameObject ball){
        IgnoreCollisionAllBalls(ball);

        balls.Add(ball);
    }

    private static void IgnoreCollisionAllBalls(GameObject ball)
    {
        foreach(var b in balls)
        {
            Physics.IgnoreCollision(b.GetComponent<Collider>(), ball.GetComponent<Collider>());
            //Console.WriteLine(item);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
