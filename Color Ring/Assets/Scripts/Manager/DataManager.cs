using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public static DataManager Instance;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void SetHighScore(int highScore)
    {
        PlayerPrefs.SetInt("highScore", highScore);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore",0);
    }
    
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion

    #region CO-ROUTINES
    #endregion

    #region EVENT_HANDLERS
    #endregion

	#region UI_CALLBACKS
	#endregion
}