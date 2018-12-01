using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using MonotypeUnityTextPlugin;

public class TimerShield : MonoBehaviour {

    public MP3DTextComponent textTimer;
    public float startTime;
    public int ShieldTime = 30;

    void Start()
    {
        startTime = Time.time;
    }

    public void resetTime(){
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = ShieldTime-(Time.time - startTime);

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f3");

        textTimer.Text = minutes + ":" + seconds;
    }
}
