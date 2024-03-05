using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ringdata", menuName = "ringdata")]
public class RingData : ScriptableObject
{
    #region PUBLIC_VARS
    public List<ColorData> colors;
    public List<SpriteData> spriteDatas;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
    public ColorData GetRandomColor()
    {
        return colors[Random.Range(0, 6)];
    }
    public SpriteData GetSpriteData(RingSize size)
    {
        return spriteDatas[(int)size];
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
[System.Serializable]
public class ColorData
{
    public ColorType colorType;
    public Color color;
}

[System.Serializable]
public class SpriteData
{
    public Sprite sprite;
    public RingSize ringSize;
}
public enum RingSize
{
    Small,
    Medium,
    Large
}
public enum ColorType
{
    RED,
    BLUE,
    GREEN,
    YELLOW,
    WHITE,
    MAGENTA
}
