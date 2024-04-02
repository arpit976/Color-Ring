using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public static UiManager Instance;
    public GamePlayView gamePlayView;
    public MainScreen mainScreen;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gamePlayView.gameObject.SetActive(false);
        mainScreen.gameObject.SetActive(true);
        GameManager.Instance.grid.gameObject.SetActive(false);
    }

    #endregion

    #region PUBLIC_FUNCTIONS

    public void OnGamePlayView()
    {
        gamePlayView.gameObject.SetActive(true);
        mainScreen.gameObject.SetActive(false);
        GameManager.Instance.Restart();
        GameManager.Instance.grid.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        GameManager gameManager = GameManager.Instance;
        gamePlayView.gameObject.SetActive(true);
        mainScreen.gameObject.SetActive(false);
        gameManager.grid.gameObject.SetActive(true);
        gameManager.StartSpawnRingCoroutine();
    }

    public void ExitGamePlayView()
    {
        gamePlayView.gameObject.SetActive(false);
        mainScreen.gameObject.SetActive(true);
        GameManager.Instance.ringHolder.ClearSlots();
        GameManager.Instance.grid.gameObject.SetActive(false);
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
