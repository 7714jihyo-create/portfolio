using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayPanel : MonoBehaviour
{

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);        
        }        
    }

    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
