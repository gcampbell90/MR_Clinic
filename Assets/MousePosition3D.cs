using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MousePosition3D : MonoBehaviour
{
    public static MousePosition3D Instance { get; private set; }

    // Normal raycasts do not work on UI elements, they require a special kind
    [SerializeField]
    GraphicRaycaster m_Raycaster;
    [SerializeField]
    PointerEventData m_PointerEventData;
    [SerializeField]
    EventSystem m_EventSystem;

    [SerializeField]
    GameObject currHitObject;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            currHitObject = raycastHit.transform.gameObject;
            //currHitObject.GetComponent<Renderer>().material.color = Color.green;
            //Debug.Log("3d Object Hit " + currHitObject.gameObject.name);

        }

        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();

        m_Raycaster.Raycast(m_PointerEventData, results);

        foreach (RaycastResult result in results)
        {
            //Debug.Log("Canvas Hit " + result.gameObject.name);
            currHitObject = result.gameObject;
        }
    }

    public static Vector3 GetMouseWorldPosition() => Instance.GetMouseWorldPosition_Instance();

    private Vector3 GetMouseWorldPosition_Instance()
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
