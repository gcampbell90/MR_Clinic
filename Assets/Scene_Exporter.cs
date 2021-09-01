using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Exporter : MonoBehaviour
{
    public static void Export_Targets()
    {
        StateTargetController.isExported = true;
        if (StateTargetController.targets ==null) { Debug.Log("No Saved Targets"); return; }
        Reinstance_Target();
        //foreach (GameObject target in StateTargetController.targets)
        //{
        //    ////Debug.Log(target);
        //    //Vector3[] vertices = target.GetComponent<MeshFilter>().mesh.vertices;

        //    ////check vertex positions
        //    //for (int i = 0; i < vertices.Length; i++)
        //    //{
                
        //    //}

        //}
 
    }

    public static void Reinstance_Target()
    {
        //Debug.Log("New Target Instance" + target.name);
        //Testing_Meshes target_Spawner = new Testing_Meshes();
        Testing_Meshes.CheckIsExported();
    }
}

