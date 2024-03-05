using UnityEngine;
using System.Collections;

public class TimerRing : Ring
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
    public IEnumerator SelfDestroyTimer(int second)
    {
        yield return new WaitForSeconds(second);
        DestroyMe();
    }
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}