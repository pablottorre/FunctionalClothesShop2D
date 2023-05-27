using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGlobalSetter : MonoBehaviour
{
    [Header("Canvas Group")]
    [SerializeField] CanvasGroup cg;

    [Header("ClockAnimation")]
    [SerializeField] Image clockFill;
    private float timerMax;

    [Header("Dialogues")]
    [SerializeField] GameObject dialogueParent;
    [SerializeField] List<DialoguesSO> buyingFromTableDialogues = new List<DialoguesSO>();
    [SerializeField] GameObject sellerPortrait;
    [SerializeField] List<DialoguesSO> darkWizardTalk = new List<DialoguesSO>();
    [SerializeField] GameObject darkWizardPortrait;
    [SerializeField] private TMP_Text dialogueText;

    [Header("StartingCinematic")]
    [SerializeField] private Image imageFade;
    [SerializeField] private float speedFade;
    private float currentFade = 1;
    bool hasTriggerStartEvent = false;

    public void Start()
    {

        EventManager.SubscribeToEvent(EventNames._GameStart, StartingCinematic);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, StartingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUISeller, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromTable, BuySomethingFromTables);
        EventManager.SubscribeToEvent(EventNames._TriggerDarkWizardDialogue, HearFromTheDarkWizard);
        timerMax = TimeSystem.instance.GetterMaxTimer();
        UpdateManager.instance.OnUpdateDelegate += OnUpdateDelegate;
    }

    public virtual void StartingSequence(params object[] parameters)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    private void StartingCinematic(params object[] parameters)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }


    public virtual void EndingSequence(params object[] parameters)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    private void BuySomethingFromTables(params object[] parameters)
    {
        StopCoroutine(HideDialogue());
        dialogueParent.SetActive(true);
        sellerPortrait.SetActive(true);
        dialogueText.text = buyingFromTableDialogues[Random.Range(0, buyingFromTableDialogues.Count)].dialogueText;
        StartCoroutine(HideDialogue());
    }

    private void HearFromTheDarkWizard(params object[] parameters)
    {
        StopCoroutine(HideDialogue());
        dialogueParent.SetActive(true);
        darkWizardPortrait.SetActive(true);
        dialogueText.text = darkWizardTalk[Random.Range(0, darkWizardTalk.Count)].dialogueText;
        StartCoroutine(HideDialogue());
    }

    IEnumerator HideDialogue()
    {
        yield return new WaitForSecondsRealtime(5);
        dialogueText.text = "";
        dialogueParent.SetActive(false);
        sellerPortrait.SetActive(false);
        darkWizardPortrait.SetActive(false);

    }

    private void OnUpdateDelegate()
    {
        clockFill.fillAmount = TimeSystem.instance.GetCurrentMinutesTime() / timerMax;


        if (!hasTriggerStartEvent)
        {
            if (currentFade > 0)
            {
                currentFade -= Time.deltaTime * speedFade;
                imageFade.fillAmount = currentFade;
            }
            else
            {
                EventManager.TriggerEvent(EventNames._EndedFadeIn);
                hasTriggerStartEvent = true;
            }
        }
    }

}
