using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class RuleManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public static RuleManager Instance;
    public List<Ring> listOfDestroyRing;
    public Raydata raydata;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        Instance = this;

    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void CheckDestroyRule(Cell currentCell, List<int> otherCellIndex)
    {
        DetectDestroyRule(currentCell, otherCellIndex);
        DestroyAll(currentCell);
    }
    public bool IsAnyPossibleMove()
    {
        List<RingSlot> ringSlot = new List<RingSlot>();
        ringSlot.AddRange(GameManager.Instance.ringHolder.ringSlots);
        List<Cell> cells = new List<Cell>();
        cells.AddRange(GameManager.Instance.grid.cells);

        for (int i = 0; i < ringSlot.Count; i++)
        {
            for (int j = 0; j < cells.Count; j++)
            {
                if (IsCellAvailableForHolderRings(ringSlot[i], cells[j]))
                    return true;
            }
        }
        return false;
    }

    private bool IsCellAvailableForHolderRings(RingSlot slot, Cell cell)
    {
        if (slot.ring.Count == 0)
            return false;

        for (int i = 0; i < cell.rings.Count; i++)
        {
            if (slot.ring[0].transform.childCount == 0)
            {
                if (IsItMatchSize(cell.rings[i], slot.ring[0]))
                    return false;
            }
            else
            {
                if (IsItMatchSize(cell.rings[i], slot.ring[0]))
                    return false;
                if (IsItMatchSize(cell.rings[i], slot.ring[0].transform.GetChild(0).GetComponent<Ring>()))
                    return false;
            }
        }

        return true;
    }
    public List<int> GetNearestCell(Vector2 position)
    {
        List<int> index = new List<int>();
        index.AddRange(GetHorizontalCellsIndex(position));
        index.AddRange(GetVerticalCellsIndex(position));
        index.AddRange(GetDiagonalCellsIndex(position));
        index = index.Distinct().ToList();
        return index;
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private void DetectDestroyRule(Cell currentCell, List<int> otherCellIndex)
    {
        SelfRule(currentCell);
        if (listOfDestroyRing.Count == 0)
        {
            LineRule(currentCell, otherCellIndex);
        }
    }
    private bool IsItMatchColor(Ring ring1, Ring ring2)
    {
        if (ring1.color == ring2.color)
            return true;
        return false;
    }
    private bool IsItMatchSize(Ring ring1, Ring ring2)
    {
        if (ring1.size == ring2.size)
            return true;
        return false;
    }
    private List<Ring> GetMatchRing(Ring ring, int cellIndex)
    {
        List<Ring> MatchRing = new List<Ring>();
        for (int i = 0; i < GameManager.Instance.grid.cells[cellIndex].rings.Count; i++)
        {
            if (IsItMatchColor(ring, GameManager.Instance.grid.cells[cellIndex].rings[i]))
                MatchRing.Add(GameManager.Instance.grid.cells[cellIndex].rings[i]);
        }
        return MatchRing;
    }
    private void LineRule(Cell currentCell, List<int> otherCellIndex)
    {
        List<Ring> matchRingForCell1;
        List<Ring> matchRingForCell2;
        for (int i = 0; i < otherCellIndex.Count; i += 2)
        {
            for (int j = 0; j < currentCell.rings.Count; j++)
            {
                matchRingForCell1 = GetMatchRing(currentCell.rings[j], otherCellIndex[i]);
                matchRingForCell2 = GetMatchRing(currentCell.rings[j], otherCellIndex[i + 1]);
                if (matchRingForCell1.Count != 0 && matchRingForCell2.Count != 0)
                {
                    listOfDestroyRing.AddRange(matchRingForCell1);
                    listOfDestroyRing.AddRange(matchRingForCell2);
                    listOfDestroyRing.Add(currentCell.rings[j]);
                }
            }
        }
        listOfDestroyRing = listOfDestroyRing.Distinct().ToList();
    }
    private void SelfRule(Cell cell)
    {
        if (IsSelfRule(cell))
        {
            foreach (Ring ring in cell.rings)
            {
                listOfDestroyRing.Add(ring);
            }
        }
    }
    private bool IsSelfRule(Cell cell)
    {
        if (cell.rings.Count < 3)
            return false;
        for (int i = 1; i < cell.rings.Count; i++)
        {
            if (!IsItMatchColor(cell.rings[i - 1], cell.rings[i]))
                return false;
        }
        return true;
    }
    private void DestroyAll(Cell currentCell)
    {
        GenerateFx(currentCell);
        for (int i = 0; i < listOfDestroyRing.Count; i++)
        {
            listOfDestroyRing[i].DamageMe();
            UiManager.Instance.gamePlayView.UpdateScore();
        }
        listOfDestroyRing.Clear();
    }



    private List<int> GetHorizontalCellsIndex(Vector2 position)
    {
        List<int> nearestCells = new List<int>();

        nearestCells.AddRange(GetLineCellsIndex(position, Direction.LEFT));
        nearestCells.AddRange(GetLineCellsIndex(position, Direction.RIGHT));

        return nearestCells;
    }
    private List<int> GetVerticalCellsIndex(Vector2 position)
    {
        List<int> nearestCells = new List<int>();

        nearestCells.AddRange(GetLineCellsIndex(position, Direction.UP));
        nearestCells.AddRange(GetLineCellsIndex(position, Direction.DOWN));

        return nearestCells;
    }
    private List<int> GetDiagonalCellsIndex(Vector2 position)
    {
        List<int> nearestCells = new List<int>();


        nearestCells.AddRange(GetLineCellsIndex(position, Direction.UP_LEFT));
        nearestCells.AddRange(GetLineCellsIndex(position, Direction.DOWN_RIGHT));
        if (nearestCells.Count < (Mathf.Sqrt(Constant.CELL_SIZE) + 1))
            nearestCells.Clear();

        nearestCells.AddRange(GetLineCellsIndex(position, Direction.UP_RIGHT));
        nearestCells.AddRange(GetLineCellsIndex(position, Direction.DOWN_LEFT));
        if (nearestCells.Count < (Mathf.Sqrt(Constant.CELL_SIZE) + 1))
            nearestCells.Clear();

        return nearestCells;
    }
    private List<int> GetLineCellsIndex(Vector2 position, Direction direction)
    {
        List<int> nearestCells = new List<int>();
        RaycastHit2D[] raycastHit = Physics2D.RaycastAll(position, raydata.GetRayVector(direction), Mathf.Infinity);

        if (raycastHit.Length != 0)
        {
            foreach (RaycastHit2D item in raycastHit)
            {
                nearestCells.Add(GameManager.Instance.grid.cells.IndexOf(item.transform.GetComponent<Cell>()));
            }
        }
        return nearestCells;
    }
    #endregion

    #region CO-ROUTINES
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
    #region FX_CALLBACKS
    private void GenerateFx(Cell currentCell)
    {
        Vector3 currentPos = currentCell.transform.position;
        for (int i = 0; i < listOfDestroyRing.Count; i++)
        {
            Vector3 otherCellPos = listOfDestroyRing[i].transform.position;
            Debug.DrawRay(currentPos, (otherCellPos - currentPos)*10, Color.red,5,true);
        }
    }
    #endregion
}