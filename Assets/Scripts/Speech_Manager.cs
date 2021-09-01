using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech_Manager : MonoBehaviour, IMixedRealitySpeechHandler
{
    [SerializeField]
    SystemManager systemManager;

    //[SerializeField]
    //GameObject doctor;
    bool doc_Present = false;

    [SerializeField]
    GameObject messageInfo;


    // Start is called before the first frame update
    void Start()
    {
        systemManager = this.GetComponent<SystemManager>();
        //sets up script to listen for events
        CoreServices.InputSystem?.RegisterHandler<IMixedRealitySpeechHandler>(this);
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.Command.Keyword.ToLower())
        {
            case "assistance please":
                Debug.Log("triggers staff members to arrive!");
                StartCoroutine(callAssistance());
        
                break;
            case "oxygen":
                Debug.Log("triggers staff member to provide oxygen");
                provide_Oxygen();
                break;
            default:
                Debug.Log($"Unknown option { eventData.Command.Keyword}");
                break;

        }
    }

    IEnumerator callAssistance()
    {
        messageInfo.SetActive(true);
   
        yield return new WaitForSeconds(3);

        spawn_Doctor();
     
    }
        void spawn_Doctor()
    {
        messageInfo.SetActive(false);
        systemManager.spawn_Doctor();
        //doctor.SetActive(true);
        doc_Present = true;
    }

    void provide_Oxygen()
    {
        if (doc_Present)
        {
            systemManager.provide_Oxygen();
        }
        else
        {
            Debug.Log("Who are you speaking to?");
        }
    }
}
