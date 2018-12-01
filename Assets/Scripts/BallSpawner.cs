using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    private int TimeRangeRandomSpawnMax = 20;
    private int TimeRangeRandomSpawnMin = 15;
    private const int TimeRandomSpawnMaxMin = 5;
    private const int TimeRandomSpawnMinMin = 0;
    private int SpawnedBalls = 0;

    private const int CANNON1 = 1;
    private const int CANNON2 = 2;
    private const int CANNON3 = 3;
    private const int CANNON4 = 4;

    private const int CANNON_MIN_RANDOM_ROTATION = -15;
    private const int CANNON_MAX_RANDOM_ROTATION = 16;

    private GameObject cannon1;
    private GameObject cannon2;
    private GameObject cannon3;
    private GameObject cannon4;

    private const string BALL0 = "Ball0";
    private const string BALL = "Ball";
    private const string BALL2 = "Ball2";

    private Color InitialCannonColor;

    private Vector3 Cannon1Position = new Vector3(-8.0f,10.7f,3.5f);
    private Vector3 Cannon2Position = new Vector3(-3.5f,10.7f,-8f);
    private Vector3 Cannon3Position = new Vector3(8.0f, 10.7f, -3.5f);
    private Vector3 Cannon4Position = new Vector3(3.5f,10.7f,8f);

    protected void SpawnBall(int cannon, string ballType){

        //Debug.Log("SpawnBall");

        Vector3 pos = Cannon1Position;
        GameObject ball = (GameObject)Instantiate(Resources.Load(ballType));
        //ball.GetComponent<MeshRenderer>().enabled = false;
        Color c = ball.GetComponent<Renderer>().material.color;

        switch(cannon){
            case CANNON1:
                ActivateCannon(cannon1, c);
                pos = Cannon1Position;
                break;
            case CANNON2:
                ActivateCannon(cannon2, c);
                pos = Cannon2Position;
                break;
            case CANNON3:
                ActivateCannon(cannon3,c);
                pos = Cannon3Position;
                break;
            case CANNON4:
                ActivateCannon(cannon4,c);
                pos = Cannon4Position;
                break;
        }

        pos = AdjustPosition(pos, ballType);
        ball.GetComponent<Rigidbody>().position = pos;
        //ball.GetComponent<MeshRenderer>().enabled = true;

        BallManager.AddBall(ball);
        SpawnedBalls++;
    }

    //adjusting smaller balls' y start position
    private Vector3 AdjustPosition(Vector3 pos, string ballType)
    {
        switch(ballType){
            case BALL:
                pos.Set(pos.x, pos.y, pos.z);
                return pos;
            case BALL2:
                pos.Set(pos.x, 10.0f, pos.z);
                return pos;
        }
        return pos;
    }

    private void ActivateCannon(GameObject cannon, Color c)
    {

        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.AddColor("_Color", c);
        cannon.GetComponent<Renderer>().SetPropertyBlock(props);
        StartCoroutine(ResetCannonColorLater(cannon, 2));

        cannon.GetComponent<AudioSource>().Play();

        Vector3 savedAngles = new Vector3(cannon.transform.eulerAngles.x, cannon.transform.eulerAngles.y, cannon.transform.eulerAngles.z);
        StartCoroutine(ResetCannonAngleLater(cannon, savedAngles, 2));

        System.Random random = new System.Random();
        int randomAngle = random.Next(CANNON_MIN_RANDOM_ROTATION, CANNON_MAX_RANDOM_ROTATION);
        cannon.transform.eulerAngles = new Vector3(cannon.transform.eulerAngles.x, cannon.transform.eulerAngles.y+randomAngle, cannon.transform.eulerAngles.z);
        //random rotation
    }

    protected void StartRecursiveRandomBallGenerator(int RangeTime){
        TimeRangeRandomSpawnMax = RangeTime;
        TimeRangeRandomSpawnMin = TimeRangeRandomSpawnMax - (TimeRandomSpawnMaxMin - TimeRandomSpawnMinMin);


        Invoke("GenerateRandomSpawningRecursive", 2);
    }

    public void CancelAllInvokes(){
        CancelInvoke();
    }

    private void GenerateRandomSpawningRecursive(){
        System.Random random = new System.Random();
        int spawnIn = random.Next(TimeRangeRandomSpawnMin, TimeRangeRandomSpawnMax);
        int cannonNumber = random.Next(1, 5);
        int ballNumber = random.Next(0, 3);
        string ballType = BallString(ballNumber);
        //Debug.Log("GenerateRandomSpawningRecursive");
        //Debug.Log(spawnIn);
        //Debug.Log(cannonNumber);
        //Debug.Log(ballNumber);


        SpawnBall(cannonNumber, ballType, spawnIn);

        Invoke("GenerateRandomSpawningRecursive", spawnIn);
    }

    private string BallString(int ballNumber)
    {
        switch(ballNumber){
            case 0:
                return BALL0;
            case 1:
                return BALL;
            case 2:
                return BALL2;

        }
        return BALL0;
    }

    IEnumerator ResetCannonAngleLater(GameObject cannon, Vector3 eulerAngles, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ResetCannonAngle(cannon, eulerAngles);
    }


    IEnumerator ResetCannonColorLater(GameObject cannon, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ResetCannonColor(cannon);
    }

    IEnumerator SpawnLater(int cannon, string ballType, float delayTime)
    {
        //Debug.Log("SpawnLater");
        yield return new WaitForSeconds(delayTime);
        //Debug.Log("SpawnLater continue");
        SpawnBall(cannon, ballType);
    }

    private void ResetCannonAngle(GameObject cannon, Vector3 eulerAngles)
    {
        cannon.transform.eulerAngles = eulerAngles;
    }

    private void ResetCannonColor(GameObject cannon)
    {
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.AddColor("_Color", InitialCannonColor);
        cannon.GetComponent<Renderer>().SetPropertyBlock(props);
    }

    protected void SpawnBall(int cannon, string ballType, float seconds)
    {
        StartCoroutine(SpawnLater(cannon, ballType, seconds));
    }


    // Use this for initialization
    protected void Start () {
        //Debug.Log("cannoni inizializzati");
        cannon1 = GameObject.Find("cannon1");
        cannon2 = GameObject.Find("cannon2");
        cannon3 = GameObject.Find("cannon3");
        cannon4 = GameObject.Find("cannon4");

        InitialCannonColor = cannon1.GetComponent<Renderer>().material.color;

    }
	
    public void IncrementTimeRangeRandomSpawnMax(int seconds){
        if(TimeRangeRandomSpawnMax+seconds > TimeRandomSpawnMaxMin){
            TimeRangeRandomSpawnMax += seconds;
        }
        else {
            TimeRangeRandomSpawnMax = TimeRandomSpawnMaxMin;
        }
    }

    public void IncrementTimeRangeRandomSpawnMin(int seconds)
    {
        if (TimeRangeRandomSpawnMin + seconds > TimeRandomSpawnMinMin)
        {
            TimeRangeRandomSpawnMin += seconds;
        }
        else
        {
            TimeRangeRandomSpawnMin = TimeRandomSpawnMinMin;
        }
    }
}
