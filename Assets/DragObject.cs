using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    float mZCoord;
    [SerializeField]
    public bool active = true;

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //mZCoord = 10f;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        //pixel coords
        Vector3 mousePoint = Input.mousePosition;
        //float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        mousePoint.z = mZCoord;
        //to world coords
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if(active == true)
        {
            transform.position = GetMouseWorldPos() + mOffset;

            //transform.position = (transform.position.x, transform.position.y, )
            //transform.position = new Vector3(GetMouseWorldPos().x, GetMouseWorldPos().y, 10f);
        }
        else
        {
            return;
        }
    }
}
