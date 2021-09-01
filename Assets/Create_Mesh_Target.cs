using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meshes
{
    private int verts;
    private int tris;
    private List<Vector3> vectorPos;

    public Meshes(int myVerts, int myTris, List<Vector3> myVectorPos)
    {
        verts = myVerts;
        tris = myTris;
        vectorPos = myVectorPos;
    }

    public Mesh Create_Mesh(Meshes myMesh)
    {
        Mesh mesh = new Mesh();

        //initialise mesh data: vertices, uvs and triangles
        Vector3[] vertices = new Vector3[myMesh.verts];
        Vector2[] uv = new Vector2[myMesh.verts];//uvs always same as verts
        int[] triangles = new int[myMesh.tris];
        List<Vector3> vectorPos = myMesh.vectorPos;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vectorPos[i].x, vectorPos[i].y, vectorPos[i].z);
        }

        //Vector3 in local space
        //vertices[0] = new Vector3(0, 0);
        //vertices[1] = new Vector3(0, 1);
        //vertices[2] = new Vector3(1, 1);
        //vertices[3] = new Vector3(1, 0);

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

        return mesh;
    }
}

