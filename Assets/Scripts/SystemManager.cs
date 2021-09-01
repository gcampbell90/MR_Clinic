using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [SerializeField]
    GameObject QR_Manager;
    //[SerializeField]
    //GameObject DEBUG_QR_Item;
    [SerializeField]
    public GameObject QR_Info_Panel;
    [SerializeField]
    GameObject QR_Item;

    [SerializeField]
    string myScene;

    [SerializeField]
    GameObject doctor;

    //[SerializeField]
    //GameObject Tapes;
    //[SerializeField]
    //GameObject m_tapes;

    //[SerializeField]
    //Animator dressing_animator;
    ////[SerializeField]
    ////AnimationClip[] animationArray;

    //[SerializeField]
    //GameObject Checklist;
    //[SerializeField]
    //List<TextMeshPro> TapesChecklist;

    //[SerializeField]
    //GameObject mySprite;

    ////List<AnimationClip> animationClips;

    //int currAnim = 0;
    //int m_checkListItem = 0;
    //int m_currentItem;
    //int listSize;

    [SerializeField]
    Scene_Loader scenes;

    private void Awake()
    {
        // Turn off all hand rays
        PointerUtils.SetHandRayPointerBehavior(PointerBehavior.AlwaysOff);

        //Turn off spatial mapping system
        CoreServices.SpatialAwarenessSystem.Disable();

    }

    private void Start()
    {
        QR_Info_Panel.SetActive(false);

        //instantiate qr manager prefab
        //Instantiate(QR_Manager, new Vector3(0, 0, 0), Quaternion.identity);
        //QR_Manager.SetActive(false);
        //Instantiate(DEBUG_QR_Item, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void Update()
    {
        if (QR_Item == null)
        {
            findQR_Variant();
            //Debug.Log("Gameobject not found");
        }
        else
        {
            QR_Info_Panel.SetActive(false);
        }
    }

    void findQR_Variant()
    {
        QR_Item = GameObject.FindGameObjectWithTag("Target");
        if (QR_Item == null)
        {
            //Debug.Log("Gameobject not found");
            return;
        }
        else
        {
            //Debug.Log("Found");
            scenes = QR_Item.GetComponent<Scene_Loader>();
            QR_Info_Panel.SetActive(false);
            Debug.Log("Loading Scene" + myScene);
            loadScene(myScene);
        }
    }

    public void loadScene(string procedure)
    {
        myScene = procedure;
        Debug.Log("QR Not present");
        if (myScene != null && QR_Item != null)
        {
            loadMyScene();
        }
    }

    void loadMyScene()
    {
        switch (myScene)
        {
            case "Tapes":
                scenes.myTapes.SetActive(true);
                //instanceScene();
                break;
            case "Assessment":
                scenes.myAssessment.SetActive(true);
                break;
            case "Suction":
                scenes.mySuction.SetActive(true);
                break;
            default:
                Debug.Log("Variant Present(Test?)");
                break;

        }
        Debug.Log("SceneLoader " + scenes + "Procedure " + myScene);
    }

    public void spawn_Doctor()
    {
        doctor = QR_Item.transform.GetChild(2).GetChild(0).gameObject;
        //doctor = GameObject.FindWithTag("Doctor");
        if (doctor == null)
        {
            Debug.Log("GO not found");
        }
        doctor.SetActive(true);
    }

    public void provide_Oxygen()
    {
      
            Animator m_drAnimation = doctor.GetComponent<Animator>();
            m_drAnimation.Play("bip|bipAction");
   
    }

    //void instanceScene()
    //{

    //    //Tapes.SetActive(true);
    //    //m_tapes = Instantiate(Tapes
    //    //    //, Tapes.transform.position, Tapes.transform.rotation
    //    //    );
    //    //m_tapes.transform.SetParent(QR_Item.transform, false);
    //    //m_tapes.transform.localRotation = Quaternion.Euler(0, 0, 0);
    //    //m_tapes.transform.parent = QR_Item.transform;
    //    //m_tapes.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
    //    //m_tapes.transform.parent = null;
    //}

    public void restart()
    {
        //Destroy(m_tapes);
        scenes.disableScenes();
    }


    // Start is called before the first frame update
    //void Start()
    //{
    //    mySprite.SetActive(false);

    //    //iterate through children of checklist to populate list of items, initally set all to false
    //    foreach (TextMeshPro child in Checklist.GetComponentsInChildren<TextMeshPro>())
    //    {
    //        TapesChecklist.Add(child);
    //        child.gameObject.SetActive(false);
    //    }
    //    listSize = TapesChecklist.Count - 1;
    //    //Debug.Log("List size: " + listSize);
    //}

    //public void loadTapes()
    //{
    //    //Tapes.SetActive(true);
    //}

    //public void nextBtn()
    //{
    //    if (m_checkListItem <= listSize)
    //    {
    //        checkListItemforward(m_checkListItem);
    //        m_checkListItem++;
    //    }
    //    else
    //    {
    //        return;
    //    }
    //    //Debug.Log("Next btn pressed" + m_checkListItem);
    //}
    //public void prevBtn()
    //{
    //    if (m_checkListItem > 0)
    //    {
    //        m_checkListItem--;
    //        checkListItemback(m_checkListItem);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //    //Debug.Log("Prev btn pressed");
    //}

    //public void next()
    //{
    //    listSize = TapesChecklist.Count;
    //    //Debug.Log(listSize);

    //    if (m_checkListItem < listSize)
    //    { 
    //        checkListItem(m_checkListItem);
    //        m_checkListItem++;
    //        //Debug.Log("ChecklistIndex " + m_checkListItem + "ListSize" + (listSize));
    //    }
    //    else
    //    {
    //        Debug.Log("Checklist out of bounds");
    //    }

    //    //if (currAnim > animationArray.Length)
    //    //{
    //    //    Debug.Log("Anim array out of bounds");
    //    //}
    //    //else
    //    //{

    //    //    dressing_animator.Play(animationArray[currAnim-1].name);
    //    //    Debug.Log("Animation no: " + currAnim);
    //    //}

    //    //if (checklistItem > listSize || checklistItem < 0)
    //    //{
    //    //    Debug.Log("Checklist out of bounds");
    //    //    return;
    //    //}
    //    //else
    //    //{
    //    //    Debug.Log("Checklist Index " + checklistItem);
    //    //    //Debug.Log(TapesChecklist[checklistItem]);
    //    //    //TapesChecklist[checklistItem].gameObject.SetActive(true);
    //    //    checklistItem++;
    //    //}
    //    //if (currAnim > animationArray.Length || currAnim < 0)
    //    //{
    //    //    Debug.Log("Array out of bounds");
    //    //    return;
    //    //}
    //    //else
    //    //{
    //    //    //dressing_animator.Play(animationArray[currAnim].name);
    //    //    currAnim++;
    //    //    Debug.Log(animationArray.Length);
    //    //    //Debug.Log("Check List No: " + checklistItem + animationArray[currAnim].name + "CurrAnim: " + currAnim);
    //    //}
    //}

    //public void prev()
    //{
    //    listSize = TapesChecklist.Count;
    //    //Debug.Log(listSize);
    //    m_checkListItem--;
    //    if (m_checkListItem > 0)
    //    {

    //        checkListItem(m_checkListItem);
    //        //Debug.Log("checklistItem " + m_checkListItem);
    //    }
    //    else
    //    {
    //        Debug.Log("Checklist out of bounds " + m_checkListItem);
    //    }
    //    //listSize = TapesChecklist.Count;
    //    ////Debug.Log(listSize);

    //    //}
    //    //TapesChecklist[checklistItem].gameObject.SetActive(false);
    //    //checklistItem--;
    //    //TapesChecklist[checklistItem].gameObject.SetActive(true);
    //    //dressing_animator.Play(animationArray[currAnim].name);
    //    //Debug.Log("Check List No: " + checklistItem + animationArray[currAnim].name + "CurrAnim: " + currAnim);
    //}

    //void checkListItemforward(int item)
    //{

    //    Debug.Log("Passed Index: " + item);
    //    mySprite.SetActive(false);
    //    TapesChecklist[item].gameObject.SetActive(true);
    //    if (item == 1)
    //    {
    //        dressing_animator.enabled = true;
    //        dressing_animator.Play("Armature|RemoveDressing");
    //    }
    //    else if(item == 2)
    //    {

    //        Destroy(dressing_animator.gameObject);
    //        mySprite.SetActive(true);
    //    }
    //}
    //void checkListItemback(int item)
    //{

    //    Debug.Log("Passed Index: " + item);

    //    TapesChecklist[item].gameObject.SetActive(false);

    //}
}
