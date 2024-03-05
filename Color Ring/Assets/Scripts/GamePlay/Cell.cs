using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell : MonoBehaviour
{
    #region PUBLIC_VARS
    public List<Ring> rings = new List<Ring>();
    public List<RingSize> availableSize;
    public List<int> cellsIndex;
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        FindNearestCell();
        StartCoroutine(DisableCollider());
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void FindNearestCell()
    {
        cellsIndex.AddRange(RuleManager.Instance.GetNearestCell(new Vector2(transform.position.x,transform.position.y)));
        cellsIndex.Remove(GameManager.Instance.grid.cells.IndexOf(this));
    }
    public void DropRing()
    {
        ExtractChild();
        RuleManager.Instance.CheckDestroyRule(this, cellsIndex);
    }
    public bool CompareRing(Ring ring)
    {
        for (int i = 0; i < this.rings.Count; i++)
        {
            if (ring.size == this.rings[i].size)
                return false;
            if (ring.transform.childCount != 0)
                if (ring.transform.GetChild(0).GetComponent<Ring>().size == this.rings[i].size)
                    return false;
        }
        return true;
    }
    public void SetAllAvailable()
    {
        availableSize.Clear();
        for (int i = 0; i < 3; i++)
        {
            availableSize.Add((RingSize)i);
        }
    }
    public void FindAvailableSpace()
    {
        for (int i = 0; i < rings.Count; i++)
        {
            availableSize.Remove(rings[i].size);
        }
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private void ExtractChild()
    {
        for (int i = 0; i < rings.Count; i++)
        {
            if (rings[i].transform.childCount != 0)
            {
                rings.Add(rings[i].GetComponentsInChildren<Ring>()[1]);
                rings[i].GetComponentsInChildren<Ring>()[1].transform.SetParent(gameObject.transform);
            }
        }
    }
    #endregion

    #region CO-ROUTINES
    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<CircleCollider2D>().enabled = false;
    }
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}