using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour
{
    #region PUBLIC_VARS
    public Cell[] dropPoints;
    public float dropSensitivity;
    #endregion

    #region PRIVATE_VARS
    private GameObject objSelected;
    #endregion

    #region UNITY_CALLBACKS
    private void Update()
    {
        PlayerInput();
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObject();
        }
        if (Input.GetMouseButton(0) && objSelected != null)
        {
            DragObject();
        }
        if (Input.GetMouseButtonUp(0) && objSelected != null)
        {
            DropObject();
        }
    }
    private void CheckHitObject()
    {
        RaycastHit2D raycastHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (raycastHit.collider != null)
        {
            objSelected = raycastHit.transform.gameObject;
        }
    }
    private void DragObject()
    {
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }
    private void DropObject()
    {
        for (int i = 0; i < dropPoints.Length; i++)
        {
            if (IsValidMove(i))
            {
                OnDrop(i);
                return;
            }
        }
        objSelected.transform.position = objSelected.transform.parent.position;
        objSelected = null;
    }

    private void OnDrop(int index)
    {
        objSelected.transform.position = dropPoints[index].transform.position;
        objSelected.GetComponent<CircleCollider2D>().enabled = false;
        objSelected.GetComponentInParent<RingSlot>().ring.Clear();
        objSelected.transform.SetParent(dropPoints[index].transform);
        dropPoints[index].rings.Add(objSelected.GetComponent<Ring>());
        dropPoints[index].GetComponent<Cell>().DropRing();
        objSelected = null;
        GameManager.Instance.ringHolder.SpawnNewRings();
        if (!RuleManager.Instance.IsAnyPossibleMove())
            Debug.Log("gameover");
    }
    private bool IsValidMove(int index)
    {
        return Vector3.Distance(dropPoints[index].transform.position, objSelected.transform.position) < dropSensitivity
                        && dropPoints[index].CompareRing(objSelected.GetComponent<Ring>());
    }
    #endregion

    #region CO-ROUTINES
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}