using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject FinalScore;
    // Start is called before the first frame update
    void Start()
    {
        FinalScore.GetComponent<Text>().text=Gemini.roundScore+"Á¡";
        Gemini.roundScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
