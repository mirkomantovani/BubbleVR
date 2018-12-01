using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicalTrigger : MonoBehaviour {


    private bool entered = false;
    public GameObject restartBall;


    private void OnTriggerEnter(Collider other)
    {
        if (!entered)
        {
            entered = true;
            Invoke("ResetEntered", 5);
            GameModeText.SetText("Classical : Level 1");
            GameManager.StartGame(GameObject.Find("GameManager").AddComponent<Classical>());
        }
    }

    private void ResetEntered()
    {
        entered = false;
        restartBall.SetActive(true);
    }
}
