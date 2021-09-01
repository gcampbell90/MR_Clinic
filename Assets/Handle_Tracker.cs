using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_Tracker : MonoBehaviour
{
    [SerializeField]
    Vector3 currPos;
    public int index;
    [SerializeField]
    Target_Builder myScript;

    private void Awake()
    {
        currPos = transform.position;
        myScript = transform.parent.GetComponent<Target_Builder>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != currPos)
        {
            currPos = transform.position;
            //Debug.Log("Pos updated to " + currPos);
            updateMesh();
        }
    }

    private void updateMesh()
    {
        myScript.moveHandles(index, transform);
    }
}
