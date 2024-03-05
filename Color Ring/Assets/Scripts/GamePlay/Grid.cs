using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    #region PUBLIC_VARS
    public List<Cell> cells;
    public List<Cell> availableCell;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void ClearCells()
    {
        for (int i = 0; i < Constant.CELL_SIZE; i++)
        {
            while (cells[i].rings.Count != 0)
            {
                Destroy(cells[i].rings[0].gameObject);
                cells[i].rings.RemoveAt(0);
            }
        }
    }
    public void FindAvailableCell()
    {
        availableCell.Clear();
        for (int i = 0; i < Constant.CELL_SIZE; i++)
        {
            cells[i].SetAllAvailable();
            cells[i].FindAvailableSpace();
            if (cells[i].availableSize.Count != 0)
            {
                availableCell.Add(cells[i]);
            }
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