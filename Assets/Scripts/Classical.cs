using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classical : BallSpawner, IGameMode
{
    private int Level = 0;
    private System.Random random = new System.Random();

    private const string SPECIAL0 = "Snowflake";
    private const string SPECIAL1 = "Bomb";
    private const string SPECIAL2 = "Shield";

    private const int SPECIALITEMSCOUNT = 3;

    private bool playing;

    //public int STARTING_SPAWN_RANDOM_SECONDS_RANGE { get; private set; }

    private const int STARTING_SPAWN_RANDOM_SECONDS_RANGE = 15;

    public void StartPlaying()
    {
        playing = true;

        StartNewLevel();

    }

    private void StartNewLevel()
    {
        if (!playing)
            return;

        BallManager.ExplodeBalls();
        BallManager.ExplodeBalls();
        BallManager.ExplodeBalls();

        Level += 1;
        GameModeText.SetText("Classical : Level "+Level);
        CancelAllInvokes();
        StartRecursiveRandomBallGenerator(GenerateTimingFromLevel());

        if(Level != 1)
            SpawnRandomSpecialItem();

        if (playing)
            Invoke("StartNewLevel", 60);
    }

    private int GenerateTimingFromLevel()
    {
        return STARTING_SPAWN_RANDOM_SECONDS_RANGE + 1 - Level;
    }
     

    // Use this for initialization
    new void Start () {
        base.Start();
    }

    private void SpawnRandomSpecialItem()
    {
        int itemNumber = random.Next(0, SPECIALITEMSCOUNT);
        SpawnRandomSpecialItem(itemNumber);
    }

    private void SpawnRandomSpecialItem(int itemNumber)
    {
        string specialName = SPECIAL0;
        switch (itemNumber)
        {
            case 0:
                specialName = SPECIAL0;
                break;
            case 1:
                specialName = SPECIAL1;
                break;
            case 2:
                specialName = SPECIAL2;
                break;

        }

        float x = (float)random.NextDouble() * 3 - 1.5f;
        float z = (float)random.NextDouble() * 3 - 1.5f;
        float y = 10f;
        GameObject specialItem = (GameObject)Instantiate(Resources.Load(specialName));
        Vector3 pos = new Vector3(x, y, z);
        specialItem.GetComponent<Rigidbody>().position = pos;
    }

}
