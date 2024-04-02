using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RingHolder : MonoBehaviour
{
    #region PUBLIC_VARS
    public List<RingSlot> ringSlots;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        //SpawnNewRings();
    }
    #endregion

    #region PUBLIC_FUNCTION
    public void SpawnNewRings()
    {
        if (AreSlotsEmpty())
        {
            GameManager.Instance.grid.FindAvailableCell();
            for (int i = 0; i < Constant.SLOT_SIZE; i++)
            {
                ringSlots[i].SetRing();
            }
        }
        /*if (AreSlotsEmpty() && GameManager.Instance.grid.availableCell.Count == 0)
        {
            GameManager.Instance.Restart();
        }*/
    }
    public void ClearSlots()
    {
        for (int i = 0; i < Constant.SLOT_SIZE; i++)
        {
            while (ringSlots[i].ring.Count != 0)
            {
                Destroy(ringSlots[i].ring[0].gameObject);
                ringSlots[i].ring.RemoveAt(0);
            }
        }
    }
    public bool AreSlotsEmpty()
    {
        foreach (RingSlot item in ringSlots)
        {
            if ((item.transform.childCount) > 0)
            {
                return false;
            }
        }
        return true;
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