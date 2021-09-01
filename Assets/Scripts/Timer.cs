using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
    public float timeElapsed = 0;
    bool timerStarted = false;
    [SerializeField]
    TextMesh[] timerItem;

    private void Awake()
    {
        timerItem[0].gameObject.SetActive(false);
    }

    public void startTimer()
    {
        if (!timerStarted)
        {
            timerItem[0].gameObject.SetActive(true);
            timerStarted = true;
        }
    }

    void Update()
    {
        if (!timerStarted) return;

        timeElapsed += Time.deltaTime;
        float time = Mathf.Round(timeElapsed * 100.0f) / 100.0f;
        updateTimer(time);
    }

    void updateTimer(float time)
    {
        timerItem[0].text = time.ToString();
    }
}
