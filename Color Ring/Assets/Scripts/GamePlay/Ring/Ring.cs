using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ring : MonoBehaviour
{
    #region PUBLIC_VARS
    public SpriteRenderer spriteRenderer;
    public ColorData colorData;
    public SpriteData spriteData;
    public RingSize size;
    public ColorType color;
    public Animator animator;
    public GameObject Tornado;
    public int DamageCount;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        DamageCount = 0;
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void SetMe(RingSize size)
    {
        colorData = GameManager.Instance.ringData.GetRandomColor();
        spriteData = GameManager.Instance.ringData.GetSpriteData(size);
        color = colorData.colorType;
        spriteRenderer.color = colorData.color;
        spriteRenderer.sprite = spriteData.sprite;
        this.size = spriteData.ringSize;
    }
    public virtual void DamageMe()
    {
        DestroyMe();
    }

    public void DestroyMe()
    {
        gameObject.GetComponentInParent<Cell>().rings.Remove(this);
       // ParticleSystem.MainModule set = Instantiate(Tornado, transform).GetComponent<ParticleSystem>().main;
        //set.startColor = this.spriteRenderer.color;
        animator.SetTrigger("Shrink");
        Destroy(gameObject, 1f);
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
