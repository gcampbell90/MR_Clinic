using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker_Follower : MonoBehaviour
{
    public GameObject Tracker;
    public Waypoint_Circuit circuit;
    float speed = 5f;
    [SerializeField]
    Transform nextObj;

    void Update()
    {
        if (circuit.nextObj != null)
        {
            nextObj = circuit.nextObj.transform;
        }
        else {
            getNextObj();
        }
        transform.position = Vector3.Lerp(transform.position, nextObj.position, Time.deltaTime * speed);
        transform.rotation = Tracker.transform.rotation;
    }

    void getNextObj()
    {
        nextObj = circuit.nextObj.transform;
    }
}
