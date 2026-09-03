using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayManager : MonoBehaviour
{
    [Header("노출시킬 팝업 패널")]
    public GameObject panel1; // Inspector에서 Panel 오브젝트를 드래그 앤 드롭 연결
    public GameObject panel2;
    public static int p_num;

    void Start()
    {
        p_num=Random.Range(1, 6);

        // 게임 시작 시 패널이 열려있다면 자동으로 닫아둡니다.
        if (panel1 != null||panel2!=null)
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
        }
    }

    // 버튼 클릭 시 실행
    public void OpenPanel()
    {
        if (panel1 != null)
        {
            panel1.SetActive(true);
            GameObject.Find("name").GetComponent<Text>().text
                = PlayerPrefs.GetString("1_name");
            GameObject.Find("age").GetComponent<Text>().text
               = PlayerPrefs.GetString("1_age");
        }
        else if (panel2 != null)
        {
            panel2.SetActive(true);
        }
    }

    // CloseButton 클릭 시 실행
    public void ClosePanel()
    {
        if (panel1 != null)
        {
            panel1.SetActive(false);
        }
    }
}
