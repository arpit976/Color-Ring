using UnityEngine;
using System.Collections;

public class RingGenerator : MonoBehaviour
{
    #region PUBLIC_VARS
    public Ring ring;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
    public Ring GetNewRing()
    {
        Ring generatedRing;
        if (GameManager.Instance.grid.availableCell.Count == 0)
        {
            return null;
        }
        int index = Random.Range(0, GameManager.Instance.grid.availableCell.Count);
        int noOfRingToSpawn = Random.Range(1, GameManager.Instance.grid.availableCell[index].availableSize.Count + 1);
        if (noOfRingToSpawn == 1)
        {
            generatedRing = SpawnAvailableRingSize(index);
        }
        else
        {
            generatedRing = SpawnAvailableRingSize(index);
            Ring childRing = SpawnAvailableRingSize(index);
            childRing.GetComponent<CircleCollider2D>().enabled = false;
            childRing.transform.SetParent(generatedRing.transform);
        }
        return generatedRing;
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private Ring SpawnAvailableRingSize(int cellIndex)
    {
        RingSize ringSize = GameManager.Instance.grid.availableCell[cellIndex].availableSize[Random.Range(0, GameManager.Instance.grid.availableCell[cellIndex].availableSize.Count)];
        Ring spawnedRing = Instantiate(ring);
        spawnedRing.SetMe(ringSize);
        RemoveUsedSlot(cellIndex, ringSize);
        return spawnedRing;
    }
    private void RemoveUsedSlot(int cellIndex, RingSize ringSize)
    {
        GameManager.Instance.grid.availableCell[cellIndex].availableSize.Remove(ringSize);
        if (GameManager.Instance.grid.availableCell[cellIndex].availableSize.Count == 0)
        {
            GameManager.Instance.grid.availableCell.RemoveAt(cellIndex);
        }
    }
    #endregion

    #region CO-ROUTINES
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}