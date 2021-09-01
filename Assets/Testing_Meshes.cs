using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Testing_Meshes 
{

    static void Create_Target(Vector3[] vertexPositions, Transform world_Pos)
    {
        List<Vector3> newList = new List<Vector3>();

        foreach (Vector3 item in vertexPositions)
        {
            newList.Add(item);
        }

        Meshes myMesh = new Meshes(4, 6, newList);
        Mesh newMesh = myMesh.Create_Mesh(myMesh);

        GameObject myTarget = new GameObject();
        myTarget.AddComponent<MeshFilter>().mesh = newMesh;
        myTarget.AddComponent<MeshRenderer>();
        myTarget.GetComponent<Renderer>().material.color = Color.green;
        myTarget.transform.position = world_Pos.position;
        myTarget.transform.rotation = world_Pos.rotation;
        myTarget.AddComponent<MeshCollider>();

    }

    public static void CheckIsExported()
    {
        if (StateTargetController.isExported)
        {
            Debug.Log(StateTargetController.targets.Count);

            foreach (var item in StateTargetController.targets)
            {
                Create_Target(item.GetComponent<MeshFilter>().mesh.vertices, item.transform);
                Debug.Log("Generating Meshes" + item.name);
            }
        }
    }
}
