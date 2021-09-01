using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    SystemManager managerScript;

    //[SerializeField]
    //Tapes_Manager tapesManagerScript;

    //Menus
    [SerializeField]
    GameObject mainMenu;
    //[SerializeField]
    //GameObject restartMenu;
    [SerializeField]
    GameObject debugInfo;

    //UI Text objects
    [SerializeField]
    TextMesh procedureString;
    //UI Text objects
    [SerializeField]
    TextMesh environmentString;
    //UI Text objects
    [SerializeField]
    TextMesh InfoOverlayString;

    [SerializeField]
    GameObject note;

    bool mode = false;//MR mode default

    enum Procedure { Blank, Tapes, Assessment, Suction }
    Procedure myProcedure;

    //strings set to pass to debugInfo
    //string myProcedure;
    string myEnvironment;
    string myInfoOverlay;

    private void Start()
    {
        debugInfo.SetActive(false);
        mainMenu.SetActive(true);
        //restartMenu.SetActive(false);
 
        myProcedure = Procedure.Blank;
        Debug.Log("Current Procedure "+ myProcedure);
    }

    public void environment(int environmentOpt)
    {
        switch (environmentOpt)
        {
            case 0:
                //Debug.Log("Hospital Ward");
                myEnvironment = "Hospital Ward";
                break;
        }
    }

    public void procedure(int procedureOpt)
    {
        switch (procedureOpt)
        {
            case 0:
                //Debug.Log("Tapes");
                //myProcedure = "Tapes & Dressings";
                myProcedure = Procedure.Tapes;
                break;
            case 1:
                //Debug.Log("Assessment");
                //myProcedure = "Assessment";
                break;
            case 2:
                //Debug.Log("Suction");
                //myProcedure = "Suction";
                break;
        }
    }

    public void toggleOn()
    {
        //Debug.Log("Overlays On");
        myInfoOverlay = "Active";
    }
    public void toggleOff()
    {
        //Debug.Log("Overlays Off");
        myInfoOverlay = "Inactive";
    }

    public void confirm()
    {
        mainMenu.SetActive(false);
        debugInfo.SetActive(true);

        procedureString.text = myProcedure.ToString();
        environmentString.text = myEnvironment;

        if (myInfoOverlay != null)
        {
            InfoOverlayString.text = myInfoOverlay;
        }
        else
        {
            toggleOn();
            InfoOverlayString.text = myInfoOverlay;
        }
    }

    public void toggleMode()
    {
        mode = !mode;
        TextMesh m_noteText = note.GetComponent<TextMesh>();
        if (!mode)
        {
            m_noteText.text = "* Note: Physical TruCorp Mannikin Required";
        }
        else {
            m_noteText.text = "* Note: No Mannikin req. Virtual Objects will be used ";
        }
    }

    public void begin()
    {

        //debugInfo.SetActive(false);
        mainMenu.SetActive(false);
        managerScript.QR_Info_Panel.SetActive(true);

        //restartMenu.SetActive(true);
        managerScript.loadScene(myProcedure.ToString());

        Debug.Log("Scene " + myProcedure);
    }
    public void change()
    {
        debugInfo.SetActive(false);
        mainMenu.SetActive(true);
        //Debug.Log("Back");
    }

    public void restart()
    {
        managerScript.restart();
        mainMenu.SetActive(true);
        //restartMenu.SetActive(false);
    }
}
