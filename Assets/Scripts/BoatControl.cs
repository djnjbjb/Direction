using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour
{
    public GameObject camera_main;
    public GameObject camera_black;
    public GameObject count_time_gameobject;
    
    public float speed;
    public bool started = false;
    public bool win = false;

    //[Range(0, 30)]
    //[SerializeField]
    //private float boat_forword_speed_max = 16f;
    //[Range(0, 30)]
    //[SerializeField]
    //private float boat_back_speed_max = 6f;
    [Range(0, 30)]
    [SerializeField]
    private float boat_forword_acceleration = 12f;
    [Range(0, 30)]
    [SerializeField]
    private float boat_back_acceleration = 8f;
    [Range(0, 10)]
    [SerializeField]
    private float boat_drag_acceleration = 4f;
    [Range(0, 360)]
    [SerializeField]
    private float boat_angularVelocity = 90f;

    [Range(0, 90)]
    [SerializeField]
    private float boat_angular_hit_min = 30f;
    [Range(0, 360)]
    [SerializeField]
    private float boat_angular_hit_max = 90f;
    [Range(0, 3)]
    [SerializeField]
    private float boat_time_hit = 1.5f;

    Rigidbody2D boat;
    CountTime count_time;
    float previous_x;
    float previous_y;
    private bool isCollision = false;

    void Start()
    {
        boat = GetComponent<Rigidbody2D>();
        started = false;
        previous_x = transform.position.x;
        previous_y = transform.position.y;
        count_time = count_time_gameobject.GetComponent<CountTime>();
    }

    private void FixedUpdate()
    {
        //Debug.Log(Time.time);
        //Debug.Log(boat.velocity);

        //Control
        if (count_time.time > 0)
        {
            if (!isCollision)
            {
                if (
                started == false
                && ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
                )
                {
                    started = true;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                    boat.angularVelocity = boat_angularVelocity;
                if (Input.GetKey(KeyCode.RightArrow))
                    boat.angularVelocity = -boat_angularVelocity;
                if (Input.GetKey(KeyCode.UpArrow))
                    boat.AddForce(boat.transform.up * boat_forword_acceleration);
                if (Input.GetKey(KeyCode.DownArrow))
                    boat.AddForce(boat.transform.up * -boat_back_acceleration);
            }
        }

        float x = transform.position.x;
        float y = transform.position.y;
        speed = Mathf.Pow(Mathf.Pow(x - previous_x, 2) + Mathf.Pow(y - previous_y, 2), 0.5f)/Time.fixedDeltaTime;
        previous_x = x;
        previous_y = y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Target")
        {
            win = true;
        }
        Debug.Log(win);

        if (!isCollision)
        {
            isCollision = true;
            StartCoroutine(CamRandom());

            /*
            var random = Random.Range(0f, 10f);
            if (random <= 1f)
            {
                camera_main.SetActive(false);
                camera_black.SetActive(true);
                StartCoroutine(TurnOffCamera());
            }
            */
        }
    }

    IEnumerator TurnOffCamera()
    {
        yield return new WaitForSeconds(boat_time_hit);
        camera_main.SetActive(true);
        camera_black.SetActive(false);
    }

    IEnumerator CamRandom()
    {
        var randomRot = Random.Range(boat_angular_hit_min, boat_angular_hit_max);
        int symbol = Random.Range(0f, 1.0f) > 0.5f ? 1 : -1;
        randomRot = symbol * randomRot;

        float curRot = camera_main.transform.rotation.eulerAngles.z;

        float timetemp = 0;
        while (timetemp <= boat_time_hit + 0.2f)
        {
            timetemp += Time.deltaTime;
            camera_main.transform.rotation = Quaternion.Lerp(camera_main.transform.rotation, Quaternion.Euler(0, 0, curRot + randomRot), Time.deltaTime / boat_time_hit);
            yield return null;
        }
        isCollision = false;
    }
}
