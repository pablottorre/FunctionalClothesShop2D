using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSprites : MonoBehaviour
{
    [SerializeField] bool inUpdate;
    [SerializeField] float orderMod;
    [SerializeField] SpriteRenderer[] spr;

    private void Awake()
    {
        LoadSpriteRenders();
    }

    void Start()
    {
        ControllerOrderLayer();
    }

    void Update()
    {
        if (inUpdate) ControllerOrderLayer();
    }


    void LoadSpriteRenders()
    {
        spr = GetComponentsInChildren<SpriteRenderer>();
    }

    void ControllerOrderLayer()
    {
        foreach (SpriteRenderer spriteRender in spr)
        {
            spriteRender.sortingOrder = -(int)((transform.position.y + orderMod) * 10);
        }
    }
}
