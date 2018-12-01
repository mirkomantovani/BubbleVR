using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayingAliveTrigger : MonoBehaviour {

    private bool entered = false;
    public GameObject restartBall;


    private void OnTriggerEnter(Collider other)
    {
        if (!entered)
        {
            entered = true;
            Invoke("ResetEntered", 5);
            GameModeText.SetText("Staying Alive Mode");
            GameManager.StartGame(GameObject.Find("GameManager").AddComponent<StayingAlive>());
        }
    }

    private void ResetEntered(){
        entered = false;
        restartBall.SetActive(true);

    }

}
