using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    #region PUBLIC_VARS
    
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
   
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion

    #region CO-ROUTINES
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS

    public void OnPlayButtonClick()
    {
        UiManager.Instance.OnGamePlayView();
    }

    public void OnResumeButtonClick()
    {

    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    #endregion
}
