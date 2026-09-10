using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDown : MonoBehaviour
{  

    public void AnyButtonDown()
    {
        if (Counting.count < 3)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Counting.count = 0;
            SceneManager.LoadScene("ResultScene");
        }
    }
    public void NextButtonDown()
    { 
        SceneManager.LoadScene("WaitingScene");
    }

    public void ResetButtonDown()
    {
        SceneManager.LoadScene("StartScene");
    }

}
