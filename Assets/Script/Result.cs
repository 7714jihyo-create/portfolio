using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Result : MonoBehaviour
{
    public static string result;
    Gemini gemini;

    // Start is called before the first frame update
    void Start()
    {
        gemini = FindObjectOfType<Gemini>();
    }

    private void Update()
    {
        if (gemini.complete)
        {
            result = gemini.result;

            print("^^"+result);
            gemini.complete = false;
        }
    }

    // Update is called once per frame

}
