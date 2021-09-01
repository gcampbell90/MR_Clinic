using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckList_Item_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject ChecklistUI, Checklist;
    [SerializeField]
    List<TextMeshPro> TapesChecklist;

    [SerializeField]
    GameObject completeScreen;

    [SerializeField]
    GameObject[] userTargets;

    int currItem = 0;
    string itemText;
    bool completed = false;
    // Start is called before the first frame update
    void Awake()
    {
        getItems();
    }

    public void getItems()
    {
        foreach (TextMeshPro child in Checklist.GetComponentsInChildren<TextMeshPro>())
        {
            TapesChecklist.Add(child);

            child.gameObject.SetActive(false);
        }
    }

    public void next()
    {

        switch (currItem)
        {
            case 0:
                itemText = "Wash and/or Sanitise Hands";
                break;
            case 1:
                userTargets[0].SetActive(false);
                itemText = "Select appropriate size of flexible suction catheter";
                break;
            case 2:
                userTargets[1].SetActive(false);
                itemText = "Assemble catheter/adapter";
                break;
            case 3:
                userTargets[2].SetActive(false);
                userTargets[3].SetActive(false);
                itemText = "Choose appropriate suction device – portable/fixed ";
                break;
            case 4:
                userTargets[4].SetActive(false);
                itemText = "Choose appropriate suction level/power";
                break;
            case 5:
                userTargets[5].SetActive(false);
                itemText = "Pass catheter until resistance felt";
                break;
            case 6:
                userTargets[6].SetActive(false);
                itemText = "Activate suction by occluding port while withdrawing catheter ";
                break;
            case 7:
                itemText = "Assess if further suction required ";
                break;
            case 8:
                itemText = "Send sample of secretions for microbiology assessment if necessary ";
                break;
            default:
                completed = true;
                break;
        }
        if (!completed)
        {
            updateText(currItem, itemText);
            currItem++;
        }
        else
        {
            complete();
            //Debug.Log("Completed");
        }

    }

    void updateText(int currItem, string text)
    {
        disableCompleted();
        TapesChecklist[currItem].gameObject.SetActive(true);
        TapesChecklist[currItem].text = (currItem + 1) + " ) " + text;
    }

    void disableCompleted()
    {
        //Debug.Log(currItem);
        if (currItem > 2 && currItem < 5)
        {
            TapesChecklist[0].gameObject.SetActive(false);
            TapesChecklist[1].gameObject.SetActive(false);
            TapesChecklist[2].gameObject.SetActive(false);
        }
        if (currItem > 5 && currItem < 8)
        {
            TapesChecklist[3].gameObject.SetActive(false);
            TapesChecklist[4].gameObject.SetActive(false);
            TapesChecklist[5].gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

    void complete()
    {
        if (currItem == 9)
        {
            ChecklistUI.SetActive(false);
            completeScreen.SetActive(true);
        }
    }

    private void Update()
    {
        foreach (GameObject usertarget in userTargets)
        {
            usertarget.transform.Rotate(transform.right, Time.deltaTime * 60f);
        }
    }
}
