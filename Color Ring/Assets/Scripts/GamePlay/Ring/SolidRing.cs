using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SolidRing : Ring
{
    #region PUBLIC_VARS
    public List<Sprite> DamageSprite; 
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        DamageCount = DamageSprite.Count;
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public override void DamageMe()
    {
        if (DamageCount == 0)
            DestroyMe();
        DamageCount--;
        spriteRenderer.sprite = DamageSprite[DamageCount];
        //ChangeSprite();
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