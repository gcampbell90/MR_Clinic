using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class TrailController : MonoBehaviour
{
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
    }
    // Start is called before the first frame update

    void Start()
    {
        GetMousePosition();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetMousePosition();
            trailRenderer.enabled = true;
        }
        else
        {
            //trailRenderer.enabled = false;
        }
    }

    private void GetMousePosition()
    {
        Vector3 pos = UtilsClass.GetMouseWorldPosition();
        transform.position = pos;
    }
}
