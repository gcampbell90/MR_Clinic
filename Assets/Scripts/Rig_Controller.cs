using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig_Controller : MonoBehaviour
{
    public GameObject L_Tracker;
    public GameObject R_Tracker;
    Vector3 distance;

    void Start()
    {
        //getDistance();
    }

    Vector3 getDistance()
    {
        Vector3 m_distance = L_Tracker.transform.position - R_Tracker.transform.position;

        return m_distance;
    }

    private void Update()
    {
        distance = getDistance();
        Debug.Log(distance);
    }
}
