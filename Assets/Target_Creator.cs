using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Creator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ActiveTargets;

    [SerializeField]
    GameObject Target_Prefab;

    Vector3 origin;

    int currTarget;

    public void create_Target()
    {
        origin = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y);
        GameObject target = Instantiate(Target_Prefab, origin, Camera.main.transform.rotation, transform);
        ActiveTargets.Add(target);
        if(ActiveTargets.Count >= 0)
        {
            currTarget = ActiveTargets.Count - 1;
        }

    }

    public void SetTarget()
    {
        if (ActiveTargets.Count >= 0)
        {
            Debug.Log("Targets Set");

            StateTargetController.targets = new List<GameObject>(ActiveTargets);
            ActiveTargets[currTarget].GetComponent<Target_Builder>().SetTarget();

        }
        else
        {
            return;
        }

        //GameObject setTarget = ActiveTargets[currTarget].gameObject;
        //StateTargetController.targets.Add(setTarget);
        //foreach (var item in ActiveTargets)
        //{
        //    item.SetActive(false);
        //}
    }

    //public void SaveScene()
    //{
    //    setTargets();
    //}

    public void exportScene()
    {
        if (ActiveTargets.Count <= 0) { Debug.Log("No Active Targets in Scene"); return; } 
        else
        {
            //StateTargetController.targets = ActiveTargets;
            Scene_Exporter.Export_Targets();
            foreach (var target in ActiveTargets)
            {
                Destroy(target);
            }
            ActiveTargets.Clear();
        }
    
    }
}
