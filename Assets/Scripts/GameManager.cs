using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private IGameMode game;

	// Use this for initialization
	void Start () {
        game = gameObject.AddComponent<StayingAlive>();
        game.StartPlaying();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
