using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameObject boat;
    public GameObject count_time_gameobject;
    public GameObject result_panel;
    public GameObject mission_panel = null;
    public GameObject go_text_gameobject;
    public GameObject result_text_gameobject;

    BoatControl boat_control;
    CountTime count_time;
    Text go_text;
    Text result_text;

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Go()
    {
        if (boat_control.win == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        boat_control = boat.GetComponent<BoatControl>();
        count_time = count_time_gameobject.GetComponent<CountTime>();
        go_text = go_text_gameobject.GetComponent<Text>();
        result_text = result_text_gameobject.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (boat_control.win || count_time.time < 0)
        {
            if (result_panel.activeSelf == false)
            {
                if (mission_panel != null)
                {
                    mission_panel.SetActive(false);
                }
                result_panel.SetActive(true);
                if (boat_control.win)
                {
                    go_text.text = "下一关";
                    result_text.text = "成功";
                }
                else
                {
                    go_text.text = "重来";
                    result_text.text = "失败";
                }
            }
        }
    }
}
