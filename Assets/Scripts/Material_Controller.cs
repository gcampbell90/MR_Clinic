using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Controller : MonoBehaviour
{
    [SerializeField]
    Material m_Material;
    [SerializeField]
    float coef = 0.2f;
    Color alpha;
    bool reducer = false;
    void Start()
    {
        m_Material = this.GetComponent<Renderer>().material;
    }
    public void alpha_Reducer()
    {
        //reduceAlpha();
        alpha = m_Material.color;
        reducer = true;
    }

    //void reduceAlpha()
    //{
    //    Color alpha = m_Material.color;
    //    alpha.a -= coef * Time.deltaTime;
    //    m_Material.color = alpha;
    //}

    private void Update()
    {
        if (reducer && alpha.a > 0)
        {
            alpha.a -= coef * Time.deltaTime;
            m_Material.color = alpha;
            Debug.Log("Reducing.." + alpha.a);
        }
        else
        {
            reducer = false;
            return;
        }

    }

}
