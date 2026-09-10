using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    [Header("노출시킬 팝업 패널")]
    public GameObject panel1; // Inspector에서 Panel 오브젝트를 드래그 앤 드롭 연결
    public GameObject panel2;
    public static int p_num;

    [Header("종족별 캐릭터 오브젝트")]
    public GameObject humanObject;       // 사람 (홍길동, 장보고)
    public GameObject ghostObject;       // 귀신/유령 (성춘향)
    public GameObject applianceObject;   // 가전제품 (냉장고)
    public GameObject animalObject;      // 동물 (뽀삐)

    void Start()
    {
        p_num=Random.Range(1, 6);

        // 게임 시작 시 패널이 열려있다면 자동으로 닫아둡니다.
        if (panel1 != null||panel2!=null)
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
        }
        ShowCharacterBySpecies();
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

    // 차트의 CloseButton 클릭 시 실행
    public void C_ClosePanel()
    {
        if (panel1 != null)
        {
            panel1.SetActive(false);
        }
    }

    public void M_ClosePanel()
    {
        if (panel2 != null)
        {
            panel2.SetActive(false);
        }
    }

    private void ShowCharacterBySpecies()
    {
        // 모든 캐릭터 우선 비활성화
        if (humanObject != null) humanObject.SetActive(false);
        if (ghostObject != null) ghostObject.SetActive(false);
        if (applianceObject != null) applianceObject.SetActive(false);
        if (animalObject != null) animalObject.SetActive(false);

        // 현재 선택된 환자의 종족값 가져오기
        string currentSpecies = PlayerPrefs.GetString(p_num + "_species");

        // 종족 이름에 따라 해당 캐릭터만 활성화
        switch (currentSpecies)
        {
            case "사람":
            case "인간":
                if (humanObject != null) humanObject.SetActive(true);
                break;
            case "귀신":
            case "유령":
                if (ghostObject != null) ghostObject.SetActive(true);
                break;
            case "가전제품":
                if (applianceObject != null) applianceObject.SetActive(true);
                break;
            case "강아지":
            case "동물":
                if (animalObject != null) animalObject.SetActive(true);
                break;
        }
    }
}
