using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public static GameManager Instance;
    public RingGenerator ringGenerator;
    public RingHolder ringHolder;
    public Grid grid;
    public RingData ringData;

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

    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void Restart()
    {
        ClearBoard();
        UiManager.Instance.gamePlayView.ResetScore();
        StartCoroutine(SpawnRing());
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private void ClearBoard()
    {
        ringHolder.ClearSlots();
        grid.ClearCells();
    }
    #endregion

    #region CO-ROUTINES
    IEnumerator SpawnRing()
    {
        yield return new WaitForSeconds(0.5f);
        ringHolder.SpawnNewRings();
    }
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}