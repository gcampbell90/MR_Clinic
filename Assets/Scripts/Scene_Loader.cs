using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Loader : MonoBehaviour
{
    //[SerializeField]
    //public GameObject Tapes;
    //[SerializeField]
    //static GameObject Assess;
    //[SerializeField]
    //static GameObject Suction;

    public GameObject myTapes;
    public GameObject myAssessment;
    public GameObject mySuction;

    private void Start()
    {
        myTapes.SetActive(false);
        myAssessment.SetActive(false);
        mySuction.SetActive(false);
    }

    public void disableScenes()
    {
        myTapes.SetActive(false);
        myAssessment.SetActive(false);
        mySuction.SetActive(false);
    }
}

