using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Follower : MonoBehaviour
{
    [SerializeField]
    Waypoint_Circuit circuit;
    GameObject[] waypoints;
    int current = 0;
    public float rotSpeed;
    public float speed;
    public float WPradius = 1;

    private void Awake()
    {
        waypoints = circuit.waypoints;
    }
    //private void Update()
    //{
    // if(Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
    //    {
    //        current++;
    //        if(current >= waypoints.Length)
    //        {
    //            current = 0;
    //        }
    //        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    //    }
    //}
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, circuit.nextObj.transform.position, Time.deltaTime * speed);
        transform.rotation = circuit.nextObj.transform.rotation;
    }
}
