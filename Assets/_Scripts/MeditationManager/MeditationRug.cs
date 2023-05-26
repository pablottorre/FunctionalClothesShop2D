using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditationRug : MonoBehaviour
{
    [Header("Logic Part")]
    [SerializeField] GameObject spriteToMeditate;
    [SerializeField] Transform positionToMeditate;

    [Header("Animation")]
    [SerializeField] Sprite desactivatedCircle;
    [SerializeField] Sprite activatedCircle;
    private SpriteRenderer sp;

    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._StartMeditating, ChangeSprite);
        EventManager.SubscribeToEvent(EventNames._StopMeditating, ChangeSprite);
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    public void EnableEAnimation()
    {
        if (spriteToMeditate.activeInHierarchy)
            spriteToMeditate.SetActive(false);
        else
            spriteToMeditate.SetActive(true);
    }

    private void ChangeSprite(params object[] parameters)
    {
        if (sp.sprite == activatedCircle)
            sp.sprite = desactivatedCircle;
        else
            sp.sprite = activatedCircle;
    }

    public Vector3 GetterPositionToMeditate()
    {
        return positionToMeditate.position;
    }
}
