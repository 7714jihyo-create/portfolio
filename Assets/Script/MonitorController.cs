using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorController : MonoBehaviour
{
    public GameObject Timer;
    public Text TimerText;
    float currenttime = 60.0f;
    public GameObject panel;
    bool timeStart=false;

    private void OnMouseDown()
    {
        Timer.SetActive(true);
        Invoke("TimeStarting", 0.5f);
        panel.SetActive(true);       
    }
    
    void TimeStarting()
    {
        timeStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart)
        {
            currenttime -= Time.deltaTime;
            TimerText.text = "" + (int)currenttime;
            if(currenttime < 0)
            {
                TimerText.text = "0";
                timeStart = false;
                GameObject.Find("Canvas").GetComponent<Gemini>().OnSubmitClick();

            }
        }
    }
}
