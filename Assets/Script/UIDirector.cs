using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("1_name", "홍길동");
        PlayerPrefs.SetString("1_age", "10대");
        PlayerPrefs.SetString("1_symptom", "자신의 그림자가 가끔 먼저 움직인다.");

        PlayerPrefs.SetString("2_name", "성춘향");
        PlayerPrefs.SetString("2_age", "400세");
        PlayerPrefs.SetString("2_species", "귀신");
        PlayerPrefs.SetString("2_symptom",
            "사람을 놀래키려고 나타났다가 본인이 먼저 놀라서 사라진다.");
        
        PlayerPrefs.SetString("3_name", "냉장고");
        PlayerPrefs.SetString("3_age", "7년");
        PlayerPrefs.SetString("3_species", "가전제품");
        PlayerPrefs.SetString("3_symptom", 
            "새벽마다 혼자 문이 열리고 내부에서 한숨 소리가 난다.");

        PlayerPrefs.SetString("4_name", "장보고");
        PlayerPrefs.SetString("4_age", "40대");
        PlayerPrefs.SetString("4_species", "인간");
        PlayerPrefs.SetString("4_symptom",
            "물을 마시면 바다의 냄새가 난다고 주장한다.");

        PlayerPrefs.SetString("5_name", "나비");
        PlayerPrefs.SetString("5_age", "3살");
        PlayerPrefs.SetString("5_species", "고양이");
        PlayerPrefs.SetString("5_symptom", "사람이 보고 있을 때만 투명해진다.");


        PlayerPrefs.Save();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
