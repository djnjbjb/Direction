using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform boat;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(boat.position.x, boat.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(boat.position.x, boat.position.y, this.transform.position.z);
    }
}
