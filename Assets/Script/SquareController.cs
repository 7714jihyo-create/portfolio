using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        panel.SetActive(true);
        if (PlayManager.p_num == 1)
        {
            GameObject.Find("name").GetComponent<Text>().text
                = PlayerPrefs.GetString("1_name");
            GameObject.Find("age").GetComponent<Text>().text
                = PlayerPrefs.GetString("1_age");
            GameObject.Find("species").GetComponent<Text>().text
                = PlayerPrefs.GetString("1_species");
            GameObject.Find("symptom").GetComponent<Text>().text
                = PlayerPrefs.GetString("1_symptom");
        }
        else if (PlayManager.p_num == 2)
        {
            GameObject.Find("name").GetComponent<Text>().text
                = PlayerPrefs.GetString("2_name");
            GameObject.Find("age").GetComponent<Text>().text
                = PlayerPrefs.GetString("2_age");
            GameObject.Find("species").GetComponent<Text>().text
                = PlayerPrefs.GetString("2_species");
            GameObject.Find("symptom").GetComponent<Text>().text
                = PlayerPrefs.GetString("2_symptom");
        }
        else if (PlayManager.p_num == 3)
        {
            GameObject.Find("name").GetComponent<Text>().text
                = PlayerPrefs.GetString("3_name");
            GameObject.Find("age").GetComponent<Text>().text
                = PlayerPrefs.GetString("3_age");
            GameObject.Find("species").GetComponent<Text>().text
                = PlayerPrefs.GetString("3_species");
            GameObject.Find("symptom").GetComponent<Text>().text
                = PlayerPrefs.GetString("3_symptom");
        }
        else if (PlayManager.p_num == 4)
        {
            GameObject.Find("name").GetComponent<Text>().text
                = PlayerPrefs.GetString("4_name");
            GameObject.Find("age").GetComponent<Text>().text
                = PlayerPrefs.GetString("4_age");
            GameObject.Find("species").GetComponent<Text>().text
                = PlayerPrefs.GetString("4_species");
            GameObject.Find("symptom").GetComponent<Text>().text
                = PlayerPrefs.GetString("4_symptom");
        }
        else if (PlayManager.p_num == 5)
        {
            GameObject.Find("name").GetComponent<Text>().text
                = PlayerPrefs.GetString("5_name");
            GameObject.Find("age").GetComponent<Text>().text
                = PlayerPrefs.GetString("5_age");
            GameObject.Find("species").GetComponent<Text>().text
                = PlayerPrefs.GetString("5_species");
            GameObject.Find("symptom").GetComponent<Text>().text
                = PlayerPrefs.GetString("5_symptom");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
