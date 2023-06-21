using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI BestScore_txt;
    public TMP_InputField Name_input;

    private void Start()
    {
        BestScore_txt.text = "Best Score: ";
        if (DataPersistenceManager.Instance.BestScore != null && !String.IsNullOrEmpty(DataPersistenceManager.Instance.BestScoreName))
        {
            BestScore_txt.text += DataPersistenceManager.Instance.BestScoreName + " : " + DataPersistenceManager.Instance.BestScore;
        }
    }

    public void StartNew()
    {
        if (!String.IsNullOrEmpty(Name_input.text))
        {
            DataPersistenceManager.Instance.CurrentPlayerName = Name_input.text;
            SceneManager.LoadScene(1);
        }
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
