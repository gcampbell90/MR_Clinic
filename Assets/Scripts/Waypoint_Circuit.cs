using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Circuit : MonoBehaviour
{
    public GameObject[] waypoints;

    [SerializeField]
    List<Transform> wpNodes;

    public GameObject tracker;
    public GameObject nextObj;

    private LineRenderer line;

    //Debug method to visualise movement track(Waypoints array manually set in inspector)
    void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
        }
    }
    private void Awake()
    {
        //creates list of nodes set up in waypoint controller
        foreach (Transform child in this.transform)
        {
            Debug.Log(child);
            wpNodes.Add(child);
            child.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        nextObj = null;
        line = GetComponent<LineRenderer>();
        line.positionCount = waypoints.Length;
        for (int i = 0; i < wpNodes.Count; i++)
        {
            line.SetPosition(i, wpNodes[i].position);
        }
    }

    public void enableLine()
    {
        line.enabled = true;
    }

    public void disableLine()
    {
        line.enabled = false;
    }
    void Update()
    {
        closestWaypoint();
    }

    void closestWaypoint()
    {
        float nearestDist = float.MaxValue;
        GameObject nearestObj = null;

        foreach (GameObject waypoint in waypoints)
        {
            float distanceToWP = (waypoint.transform.position - tracker.transform.position).sqrMagnitude;
            if (distanceToWP < nearestDist)
            {
                nearestDist = distanceToWP;
                nearestObj = waypoint;
                nextObj = nearestObj;
            }
        }

        Debug.DrawLine(tracker.transform.position, nearestObj.transform.position, Color.red);
    }
}

