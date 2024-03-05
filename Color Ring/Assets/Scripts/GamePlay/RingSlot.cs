using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RingSlot : MonoBehaviour
{
    #region PUBLIC_VARS
    public List<Ring> ring = new List<Ring>();
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void SetRing()
    {
        ring.Clear();
        ring.Add(GameManager.Instance.ringGenerator.GetNewRing());
        if (ring[0] == null)
            ring.Clear();
        for (int i = 0; i < ring.Count; i++)
        {
            ring[i].transform.SetParent(transform, false);
        }
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