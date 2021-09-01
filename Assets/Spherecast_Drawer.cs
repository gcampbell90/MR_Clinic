using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spherecast_Drawer : MonoBehaviour
{
    public GameObject currHitObject;

    public float radius;
    public float maxDistance;
    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 dir;

    [SerializeField]
    private float currHitDistance;

    private void Update()
    {
        origin = transform.position;
        dir = transform.forward;
        RaycastHit hit;

        if (Physics.SphereCast(origin, radius, dir, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currHitObject = hit.transform.gameObject;
            currHitDistance = hit.distance;


            Renderer rend = hit.transform.GetComponent<Renderer>();
            SphereCollider sphereCollider = hit.collider as SphereCollider;
            //MeshCollider meshCollider = hit.collider as MeshCollider;

            if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || sphereCollider == null)
                return;

            Texture2D tex = rend.material.mainTexture as Texture2D;
            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= tex.width;
            pixelUV.y *= tex.height;

            Debug.Log("X " + pixelUV.x + " Y:" + pixelUV.y);
            //original

            tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
            //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);

            tex.Apply();

        }
        else
        {
            currHitObject = null;
            currHitDistance = maxDistance;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + dir * currHitDistance);
        Gizmos.DrawWireSphere(origin + dir * currHitDistance, radius);
    }
}
