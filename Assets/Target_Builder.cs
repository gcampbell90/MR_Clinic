using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Builder : MonoBehaviour
{

    [SerializeField]
    Vector3[] vectorPos;
    [SerializeField]
    List<Vector3> worldPos;
    [SerializeField]
    List<Transform> handles;

    GameObject target;

    public GameObject sphereHandle;

    int currIndex;
    [SerializeField]
    Transform selectedHandle;

    int verts = 4;
    //int uv = 3;
    int tri = 6;

    private void Start()
    {
        target = gameObject;
        //initialise mesh
        Mesh mesh = new Mesh();

        //initialise mesh data: vertices, uvs and triangles
        Vector3[] vertices = new Vector3[verts];
        Vector2[] uv = new Vector2[verts];//uvs always same as verts
        int[] triangles = new int[tri];

        //Vector3 in local space
        vertices[0] = new Vector3(0, 0);
        vertices[1] = new Vector3(0, 1);
        vertices[2] = new Vector3(1, 1);
        vertices[3] = new Vector3(1, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        //vector2 data normalised
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        //set mesh data to mesh
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        //set mesh filter with mesh
        target.GetComponent<MeshFilter>().mesh = mesh;

        //set default material to color
        target.GetComponent<Renderer>().material.color = Color.green;

        target.GetComponent<MeshCollider>().sharedMesh = mesh;
   
        vectorPos = vertices;
        getHandles();
    }

    private void getHandles()
    {
        worldPos = new List<Vector3>();
        handles = new List<Transform>();
        for (int i = 0; i < vectorPos.Length; i++)
        {
            worldPos.Add(transform.TransformPoint(vectorPos[i]));
            GameObject handle = Instantiate(sphereHandle, worldPos[i], Quaternion.identity, transform);
            handles.Add(handle.transform);
            handle.GetComponent<Handle_Tracker>().index = i;
            handle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            //Debug.Log(worldPos);
            //Debug.Log(transform.TransformPoint(vertices[i]));
        }
    }

    public void moveHandles(int index, Transform handle)
    {
        //Debug.Log(index + " " + handle.position);
        currIndex = index;
        selectedHandle = handle;
        vectorPos[index] = transform.InverseTransformPoint(selectedHandle.position);
        updateMesh();
    }

    public void SetTarget()
    {
        foreach(Transform handle in handles)
        {
            Destroy(handle.gameObject);
                //.(false);
        }
        //target.GetComponent<MeshCollider>().sharedMesh = target.GetComponent<MeshFilter>().mesh;
        target.GetComponent<MeshCollider>().enabled = false;

        //target.GetComponent<DragObject>().active = false;

    }

    void updateMesh()
    {
        transform.rotation = Camera.main.transform.rotation;
        target.GetComponent<MeshFilter>().mesh.vertices = vectorPos;

        Debug.Log("Recalculate collider");
        target.GetComponent<MeshCollider>().sharedMesh = target.GetComponent<MeshFilter>().mesh;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
