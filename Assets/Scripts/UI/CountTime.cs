using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public Text text;
    public float TIME_LIMITED = 80;
    public float time;
    public GameObject boat;

    BoatControl boat_control;
    float start_time;
    bool boat_started = false;
    // Start is called before the first frame update
    void Start()
    {
        boat_control = boat.GetComponent<BoatControl>();
        text = GetComponent<Text>() as Text;
        start_time = 0;
        time = TIME_LIMITED;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (boat_started == false && boat_control.started == true)
        {
            boat_started = true;
            start_time = Time.time;
        }

        if (boat_started == false)
        {
            time = TIME_LIMITED;
        }
        else
        {
            time = TIME_LIMITED - (Time.time - start_time);
        }

        if (time > 0)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time % 60;
            text.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        else
        {
            text.text = "00" + ":" + "00";
        }
    }
}
