using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Utils
{
    public static class UtilsClass
    {
        public static Vector3 GetMouseWorldPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
            {
                return raycastHit.point;
            }
            else
            {
                return Vector3.zero;
            }
        }

    }
}
