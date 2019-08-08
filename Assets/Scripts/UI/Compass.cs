using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject main_camera;
    public GameObject boat;
    public GameObject target;
    public GameObject compass;
    public GameObject compass_arrow;
    public float compass_show_speed_threshold = 0.3f;
    public float half_angle_range = 45f;
    public float min_angular_velocity = 45f;
    public float max_angular_velocity = 180f;
    public float min_ang_vel_distance = 100f;
    public float max_ang_vel_distance = 20f;

    Text speed_text;
    Text mileage_text;
    BoatControl boat_control;
    float mileage;
    float speed_pre;
    float mid_angle;
    float start_angle;
    float angular_velocity;
    float compass_start_time;
    // Start is called before the first frame update
    void Start()
    {
        boat_control = boat.GetComponent<BoatControl>();
        compass.SetActive(true);
        compass_arrow.transform.eulerAngles = new Vector3(0, 0, 0);

        speed_text = GameObject.Find("Speed").GetComponent<Text>();
        mileage_text = GameObject.Find("Mileage").GetComponent<Text>();
        mileage = 0;

        speed_pre = compass_show_speed_threshold * 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //boat_control.boat_started
        //float time_zero_speed;

        mileage += boat_control.speed * Time.fixedDeltaTime;
        speed_text.text = "速度  " + boat_control.speed.ToString("#0.##") + " m/s";
        mileage_text.text = "里程  " + mileage.ToString("###0.##") + " m/s";

        bool active = boat_control.speed <= compass_show_speed_threshold ? true : false;
        if (active != compass.activeSelf)
        {
            compass.SetActive(active);
        }

        if (speed_pre > compass_show_speed_threshold )
        {
            float x = target.transform.position.x - boat.transform.position.x;
            float y = target.transform.position.y - boat.transform.position.y;
            float real_angle_in_angular = Mathf.Atan2(y, x) * 180f / Mathf.PI;
            real_angle_in_angular = real_angle_in_angular - 90;
            mid_angle = real_angle_in_angular + Random.Range(-half_angle_range, half_angle_range);
            start_angle = mid_angle + Random.Range(-half_angle_range, half_angle_range);
            float distance = Mathf.Sqrt(x * x + y * y);
            distance = Mathf.Clamp(distance, min_ang_vel_distance, max_ang_vel_distance);
            angular_velocity = Mathf.Lerp(min_angular_velocity, max_angular_velocity, (max_ang_vel_distance - distance) / (max_ang_vel_distance - min_ang_vel_distance));
            
            compass_start_time = Time.time;
        }

        if (active)
        {
            //总是先逆时针转动
            float min = mid_angle - half_angle_range;
            float max = mid_angle + half_angle_range;

            float time = Time.time - compass_start_time;
            float angle_rotated = angular_velocity * time;
            angle_rotated = angle_rotated % (half_angle_range *2 * 2);
            float angle_to_left = start_angle - min;

            float current_angle = start_angle;
            if (angle_rotated <= angle_to_left)
            {
                current_angle = start_angle - angle_rotated;
            }
            else if (angle_rotated <= (angle_to_left + (half_angle_range*2)))
            {
                current_angle = angle_rotated - angle_to_left + min;
            }
            else
            {
                current_angle = max - (angle_rotated - (angle_to_left + (half_angle_range*2)));
            }



            compass_arrow.transform.eulerAngles = new Vector3(0, 0, current_angle) - main_camera.transform.eulerAngles;
        }

        speed_pre = boat_control.speed;
    }
}
