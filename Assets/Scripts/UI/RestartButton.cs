using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    public void RestartButtonFunction()
    {
        ResetMoney();
        LoadScene();
    }
    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    void ResetMoney()
    {
        CurrentMoney.CurrentGold = 0;
        CurrentMoney.CurrentGem = 0;
    }
}
