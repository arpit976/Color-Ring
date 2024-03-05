using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "raydata", menuName = "raydata")]
public class Raydata : ScriptableObject
{
    #region PUBLIC_VARS
    public List<DirectionData> directionDatas;
    #endregion

    #region PRIVATE_VARS
    public Vector2 GetRayVector(Direction direcation)
    {
        return directionDatas[(int)direcation].vector2;
    }
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
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

[System.Serializable]
public class DirectionData
{
    public Direction direction;
    public Vector2 vector2;
    
}
public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    UP_LEFT,
    UP_RIGHT,
    DOWN_LEFT,
    DOWN_RIGHT
}