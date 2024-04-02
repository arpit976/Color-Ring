using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayView : MonoBehaviour
{
    #region PUBLIC_VARS
    public Text currentScoreText;
    public Text highScoreText;
    #endregion

    #region PRIVATE_VARS
    private int highScore;
    private int currentScore;
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        currentScore = 0;
        highScore = DataManager.Instance.GetHighScore();
    }
    private void Start()
    {
        highScoreText.text = highScore.ToString();
        currentScoreText.text = currentScore.ToString();
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void UpdateScore()
    {
        currentScore += 10;
        currentScoreText.text = currentScore.ToString();
        if (currentScore > highScore)
            SetHighScore();
    }
    public void ResetScore()
    {
        currentScore = 0;
        currentScoreText.text = currentScore.ToString();
    }
    
    #endregion

    #region PRIVATE_FUNCTIONS
    private void SetHighScore()
    {
        highScore = currentScore;
        highScoreText.text = highScore.ToString();
        DataManager.Instance.SetHighScore(highScore);
    }
    #endregion

    #region CO-ROUTINES
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    public void OnExitClick()
    {
        UiManager.Instance.ExitGamePlayView();
    }
    public void OnRestartClick()
    {
        GameManager.Instance.Restart();
    }

    #endregion

}
