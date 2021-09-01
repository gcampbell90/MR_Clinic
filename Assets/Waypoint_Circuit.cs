using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Circuit : MonoBehaviour
{
    //public GameObject[] waypoints;
    public bool lineToggle = true;
    [SerializeField]
    List<Transform> wpNodes;
    [SerializeField]
    List<GameObject> clones;

    public GameObject tracker;
    public GameObject nextObj;

    private LineRenderer line;

    [SerializeField]
    GameObject item;

    //Debug method to visualise movement track(Waypoints array manually set in inspector)
    //void OnDrawGizmos()
    //{
    //    for (int i = 0; i < wpNodes.Count - 1; i++)
    //    {
    //        Gizmos.DrawLine(wpNodes[i].transform.position, wpNodes[i + 1].transform.position);
    //    }
    //}

    private void Awake()
    {
        TriggerUpdate();
    }
    public void TriggerUpdate()
    {
        UpdateWP();
    }

    private void UpdateWP()
    {
        //creates list of nodes set up in waypoint controller
        foreach (Transform child in this.transform)
        {
            wpNodes.Add(child);
            child.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        line = GetComponent<LineRenderer>();
        line.positionCount = wpNodes.Count;
        for (int i = 0; i < wpNodes.Count; i++)
        {
            //line renderer
            line.SetPosition(i, wpNodes[i].position);

            Vector3 start = wpNodes[i].position;
            Vector3 end = new Vector3();

            if (i < wpNodes.Count - 1)
            {
                end = wpNodes[i + 1].position;
                //Debug.Log("Less than");
                //Debug.Log("i=" + i + "Count " + wpNodes.Count);

            }
            else if (i == wpNodes.Count - 1)
            {
                return;
                //end = wpNodes[0].position;
            }
            Vector3 centre = (start + end) / 2;
            centre.z = this.transform.position.z;
            clones.Add(Instantiate(item, centre, Quaternion.identity, wpNodes[i].transform));
            clones[i].GetComponent<ScaleWithPivots>().UpdateTransformScale(start, end);
        }



        //for (int j = 0; j < wpNodes.Count - 1; j++)
        //{
        //    Vector3 start = wpNodes[j].position;
        //    Vector3 end = wpNodes[j + 1].position;
        //    Vector3 centre = (start + end) / 2;
        //    //float distance = Vector3.Distance(start, end);

        //    Instantiate(item, centre, Quaternion.identity, wpNodes[j].transform);

        //    //clone.GetComponent<ScaleWithPivots>().UpdateTransformScale(start, end);
        //    //item.GetComponent<ScaleWithPivots>().UpdateTransformScale(start, end);
        //    //Vector3 InitialScale = item.transform.localScale;

        //    //item.transform.localScale = new Vector3(InitialScale.x, distance, InitialScale.z);

        //    //item.GetComponent<ScaleWithPivots>().SetPivots(wpNodes[]
        //    //Debug.Log(item.transform.localScale);

        //    //Debug.Log(distance);
        //}
        //foreach (Transform child in wpNodes)
        //{
        //    clones.Add(wpNodes.GetComponentinChildren<Transform>());
        //    Debug.Log(clones);
        //}

    }

    private void Update()
    {
        if (line != null)
        {
            if (lineToggle == true)
            {
                //Debug.Log("Checking toggle status");
                if (line.enabled != true)
                {
                    enableLine();
                }
                else
                {
                    return;
                }
            }
            else if (line.enabled != false)
            {
                disableLine();
            }
        }
    }

    public void enableLine()
    {
        Debug.Log("Enabling");
        line.enabled = true;
    }

    public void disableLine()
    {
        Debug.Log("Disabling");
        line.enabled = false;
    }
    //void Update()
    //{
    //    closestWaypoint();
    //}

    //void closestWaypoint()
    //{
    //    float nearestDist = float.MaxValue;
    //    GameObject nearestObj = null;

    //    foreach (GameObject waypoint in waypoints)
    //    {
    //        float distanceToWP = (waypoint.transform.position - tracker.transform.position).sqrMagnitude;
    //        if (distanceToWP < nearestDist)
    //        {
    //            nearestDist = distanceToWP;
    //            nearestObj = waypoint;
    //            nextObj = nearestObj;
    //        }
    //    }

    //    Debug.DrawLine(tracker.transform.position, nearestObj.transform.position, Color.red);
    //}
}

