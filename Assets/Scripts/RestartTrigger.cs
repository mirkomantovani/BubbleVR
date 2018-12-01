using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTrigger : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet") {
        Debug.Log("Restart trigger restart ball hit");
        RestartGame.DetachFloor();
        Invoke("RestartScene", 3);
        }
    }

    private void RestartScene(){
        RestartGame.RestartScene();
    }

        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
