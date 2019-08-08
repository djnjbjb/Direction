using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject camera_main;
    public GameObject camera_black;

    // Start is called before the first frame update
    void Awake()
    {
        camera_main.SetActive(true);
        camera_black.SetActive(false);

        int seed = System.DateTime.Now.Millisecond;
        Random.InitState(System.DateTime.Now.Millisecond);
        Debug.Log("Seed:" + seed);
    }
}
