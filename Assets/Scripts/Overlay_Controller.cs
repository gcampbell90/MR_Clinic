using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Overlay_Controller : MonoBehaviour
{

    [SerializeField]
    TextMeshPro InfoText;
    [SerializeField]
    GameObject Pointer1;
    [SerializeField]
    GameObject Pointer2;

    string info1 = "Tracheostomy tube placement between the second and third tracheal rings";
    string info2 = "Cricoid Cartilage";
    string info3 = "Tracheostomy blah blah 3...";

    private void Start()
    {
        Pointer1.SetActive(true);
        Pointer2.SetActive(false);
    }

    public void next()
    {
        InfoText.text = info2;
        Pointer1.SetActive(false);
        Pointer2.SetActive(true);
    }

    public void prev()
    {
        InfoText.text = info1;
        Pointer1.SetActive(true);
        Pointer2.SetActive(false);
    }
}
