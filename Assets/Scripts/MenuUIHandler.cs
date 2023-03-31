using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI inputField;
    public void Start()
    {
        DataCollector.Instance.LoadPlayerHighScore();
        highScoreText.text = ("Best Score : " + DataCollector.Instance.goldPlayerName + " : " + DataCollector.Instance.highScore);
    }
    public void StartGame()
    {
        DataCollector.Instance.PlayerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    public void Highscores()
    {
        SceneManager.LoadScene(2);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
