using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tapes_Manager : MonoBehaviour
{
    //Items
    [SerializeField]
    GameObject Tapes;
    [SerializeField]
    Animator dressing_animator;
    //[SerializeField]
    //GameObject doctor;
    //[SerializeField]
    //AnimationClip[] animationArray;

    //Info panels
    [SerializeField]
    GameObject Intro_Info, SuctionTypes, Feedback;
    [SerializeField]
    GameObject Checklist;
    [SerializeField]
    List<TextMeshPro> TapesChecklist;

    [SerializeField]
    GameObject mySprite;

    int currAnim = 0;
    int m_checkListItem = 0;
    int m_currentItem;
    int listSize;

    void Awake()
    {
        //suction
        //Intro_Info.SetActive(true);
        //mySprite.SetActive(false);

        Checklist.SetActive(true);
        //iterate through children of checklist to populate list of items, initally set all to false
        foreach (TextMeshPro child in Checklist.GetComponentsInChildren<TextMeshPro>())
        {
            TapesChecklist.Add(child);
            child.gameObject.SetActive(false);
        }
        listSize = TapesChecklist.Count - 1;
        //Debug.Log("List size: " + listSize);
    }

    public void nextBtn()
    {
        if (m_checkListItem <= listSize)
        {
            checkListItemforward(m_checkListItem);
            m_checkListItem++;
        }
        else
        {
            return;
        }
        //Debug.Log("Next btn pressed" + m_checkListItem);
    }
    public void prevBtn()
    {
        if (m_checkListItem > 0)
        {
            m_checkListItem--;
            checkListItemback(m_checkListItem);
        }
        else
        {
            return;
        }
        //Debug.Log("Prev btn pressed");
    }

    void checkListItemforward(int item)
    {

        Debug.Log("Passed Index: " + item);
        mySprite.SetActive(false);
        TapesChecklist[item].gameObject.SetActive(true);
        if (item == 1)
        {
            dressing_animator.enabled = true;
            dressing_animator.Play("Armature|RemoveDressing");
        }
        else if (item == 2)
        {

            Destroy(dressing_animator.gameObject);
            mySprite.SetActive(true);
        }
    }
    void checkListItemback(int item)
    {

        Debug.Log("Passed Index: " + item);

        TapesChecklist[item].gameObject.SetActive(false);

    }

    void perform_Action()
    {
        //Material_Controller.alpha_Reducer();
    }

}
