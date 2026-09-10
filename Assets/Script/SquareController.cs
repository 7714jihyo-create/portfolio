using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    public GameObject panel;

    private void OnMouseDown()
    {

        panel.SetActive(true);

        int num = PlayManager.p_num;

        GameObject.Find("name").GetComponent<Text>().text = PlayerPrefs.GetString(num + "_name");
        GameObject.Find("age").GetComponent<Text>().text = PlayerPrefs.GetString(num + "_age");
        GameObject.Find("species").GetComponent<Text>().text = PlayerPrefs.GetString(num + "_species");
        GameObject.Find("symptom").GetComponent<Text>().text = PlayerPrefs.GetString(num + "_symptom");

    }

}
