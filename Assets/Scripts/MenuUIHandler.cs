using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField Input;

    public TextMeshProUGUI BestScore;


    public void Start()
    {
        Player bestPlayer = HandleScore.s_Instance.ReadJsonAndReturnBestPlayer();
        if (bestPlayer != null)
        {
            BestScore.text = "Best Score : " + bestPlayer.Name + " : " + bestPlayer.Score;
        }
    }

    public void StartNew()
    {
        HandleScore.s_Instance.SetPlayerName(Input.text);
        SceneManager.LoadScene(1);
    }

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}

