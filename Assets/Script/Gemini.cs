using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gemini : MonoBehaviour
{
    [Header("[ API 설정 ]")]
    //API 키 발급 사이트 : https://aistudio.google.com/app/apikey
    [SerializeField] private string apiKey = ""; // api 키 입력

    private const string API_URL =
    "https://generativelanguage.googleapis.com/v1beta/models/gemini-3.6-flash:generateContent?key=";


    [Header("[ UI 컴포넌트 연결 ]")]
    [SerializeField] private InputField disease;
    [SerializeField] private InputField reason;
    [SerializeField] private InputField prescription;

    [Header("[ 버튼 제어 ]")]
    [SerializeField] private Button GeminiButton;
    [SerializeField] private Text outputText;

    public string result;
    public bool complete=false;
    public static int roundScore=0;



    // [제출] 버튼의 OnClick() 이벤트에 연결
    public async void OnSubmitClick()
    {
        // 클릭하자마자 버튼을 바로 비활성화 (중복 누름 방지)
        GeminiButton.interactable = false;
        Debug.Log("버튼이 클릭되어 비활성화되었습니다.");

        string pName = PlayerPrefs.GetString(PlayManager.p_num + "_name", "아무개");
        string pSpecies = PlayerPrefs.GetString(PlayManager.p_num + "_species", "환자");
        string pSymptom = PlayerPrefs.GetString(PlayManager.p_num + "_symptom", "증상 미상");

        string userQuery = string.Format(
            GamePrompt.PROMPT,
            pName,
            pSpecies,
            pSymptom,
            disease.text,
            reason.text,
            prescription.text
        ); // ai의 판결을 위한 프롬프트

        if (outputText != null)
        {
            outputText.text = "Gemini가 답변을 생각 중입니다...";
        }

        Debug.Log("[Gemini] 요청을 시작합니다...");

        result = await SendRequest(userQuery);

        Debug.Log("[Gemini] 응답 완료!");
        roundScore += ExtractScoreNumber(result);

        if (outputText != null)
        {
            complete = true;
            outputText.text = result;          
        }
        GameObject.Find("NextButton").GetComponent<Button>().interactable = true;
    }
    private int ExtractScoreNumber(string responseText)
    {
        // "점수:" 뒤에 나오는 숫자(\d+) 영역을 캡처하는 정규식 패턴
        Match match = Regex.Match(responseText, @"점수\s*:\s*(\d+)점?");

        if (match.Success)
        {
            // 괄호()로 지정한 첫 번째 그룹(숫자만 해당)을 정수로 변환하여 반환
            return int.Parse(match.Groups[1].Value);
        }

        // 혹시 포맷이 미세하게 틀렸을 경우 대비 예외 처리 (숫자만 탐색)
        Match fallbackMatch = Regex.Match(responseText, @"\d+");
        if (fallbackMatch.Success)
        {
            return int.Parse(fallbackMatch.Value);
        }

        return 0; // 추출 실패 시 기본값
    }


private async Task<string> SendRequest(string userPrompt)
    {
        string cleanApiKey = apiKey.Trim();

        if (string.IsNullOrEmpty(cleanApiKey))
        {
            Debug.LogError("API 키가 설정되지 않았습니다.");
            return "오류: API 키 누락";
        }

        string fullUrl = API_URL + cleanApiKey;

        string jsonBody =
            "{\"contents\":[{\"parts\":[{\"text\":\"" +
            EscapeJson(userPrompt) +
            "\"}]}]}";

        using (UnityWebRequest request = new UnityWebRequest(fullUrl, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);

            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");

            var operation = request.SendWebRequest();

            while (!operation.isDone) // gemini가 질문에 대한 답변 여부 체크
            {
                await Task.Yield(); 
            }
            // 이 위치에 도달하면 제미나이 답변 완료 상태
            if (request.result == UnityWebRequest.Result.Success) //정상 완료
            {
                return ParseResponseText(request.downloadHandler.text);
            }
            else // 비정상 완료
            {
                Debug.LogError($"[에러 코드] {request.responseCode}");
                Debug.LogError($"[에러 내용] {request.downloadHandler.text}");

                return $"요청 실패 (코드: {request.responseCode})";
            }
        }
    }

    private string EscapeJson(string text)
    {
        return text.Replace("\\", "\\\\")
                   .Replace("\"", "\\\"")
                   .Replace("\n", "\\n")
                   .Replace("\r", "\\r");
    }

    private string ParseResponseText(string jsonResponse)
    {
        try
        {
            ResponseData responseData =
                JsonUtility.FromJson<ResponseData>(jsonResponse);

            if (responseData != null &&
                responseData.candidates != null &&
                responseData.candidates.Length > 0 &&
                responseData.candidates[0].content != null &&
                responseData.candidates[0].content.parts != null &&
                responseData.candidates[0].content.parts.Length > 0)
            {
                return responseData.candidates[0].content.parts[0].text;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("파싱 에러: " + e.Message);
        }

        return "응답 파싱 실패";
    }

    [Serializable] // 직렬화
    private class ResponseData
    {
        public Candidate[] candidates;
    }

    [Serializable]
    private class Candidate
    {
        public Content content;
    }

    [Serializable]
    private class Content
    {
        public Part[] parts;
    }

    [Serializable]
    private class Part
    {
        public string text;
    }
}