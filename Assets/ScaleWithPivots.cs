using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithPivots : MonoBehaviour
{
    private Vector3 initialScale;
    private Vector3 start, end;

    private void Start()
    {
        initialScale = this.transform.localScale;
    }

    public void UpdateTransformScale(Vector3 start, Vector3 end)
    {
        this.start = start;
        this.end = end;
        Vector3 centre = (start + end) / 2;
        Vector3 rot = (end - start);
        
        //Vector3 distance = (start - end) / 2;
        float distance = Vector3.Distance(start, end);

        this.transform.localScale = new Vector3(1f, distance, 1f);
        this.transform.up = rot;
    }
}
