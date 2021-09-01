using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Shape : MonoBehaviour
{
    [SerializeField]
    GameObject item;
    Waypoint_Circuit wpCircuitController;
    // Update is called once per frame

    private void Start()
    {
        wpCircuitController = this.GetComponent<Waypoint_Circuit>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = MouseTracker3D.GetMouseWorldPosition();
            //Debug.Log(pos.ToString());
            Instantiate(item, pos, Quaternion.identity, this.transform);
            wpCircuitController.TriggerUpdate();
        }
    }
}
