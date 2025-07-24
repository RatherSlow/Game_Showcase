using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    // References
    //[SerializeField] private List<RegionData> availableRegions;
    [SerializeField] private List<KnightData> availableKnights;
    [SerializeField] private List<QuestData> availableQuests;

    [SerializeField] private GameObject questMapPanel;
    [SerializeField] private Transform questDetailPanel;
    //[SerializeField] private Transform regionContainer;

    [SerializeField] private GameObject knightListPanel;
    [SerializeField] private Transform knightListContent;
    [SerializeField] private GameObject knightEntryPrefab;

    [SerializeField] private GameObject questEntryPrefab;
    [SerializeField] private Transform questListContent;

    [SerializeField] private GameObject questOutcomePanel;
    [SerializeField] private GameObject topBarPanel;

    [SerializeField] private QuestOutcomeUI questOutcomeUI;

    [SerializeField] private Button sendButton;

    private KnightEntryUI selectedKnightUI;
    private QuestUI selectedQuestUI;

    private void Start()
    {
        PopulateKnightList();
        PopulateQuestList();
        sendButton.interactable = false;
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }


    // Selected Units
    private RegionData selectedRegion;
    private KnightData selectedKnight;
    private QuestData selectedQuest;
    // Currently selected knight and quest for assignment.

    private void HandleKnightSelected(KnightData knight, KnightEntryUI knightUI)
    {        
        if (selectedKnightUI != null)
            selectedKnightUI.SetSelected(false); // unhighlight previous

        selectedKnight = knight;
        selectedKnightUI = knightUI;
        Debug.Log($"Selected knight: {knight.knightName}");

        selectedKnightUI.SetSelected(true);
        UpdateSendButtonState();
    }

    // Assignment Logic
    public void AssignKnightToQuest(KnightData knight, QuestData quest)
    {
        ResolveQuest(knight, quest/*, selectedRegion*/);
    }   

    private void HandleQuestSelected(QuestData quest, QuestUI QuestUI)
    {
        if (selectedQuestUI != null)
            selectedQuestUI.SetSelected(false); // unhighlight previous

        selectedQuest = quest;
        selectedQuestUI = QuestUI;
        Debug.Log($"Selected quest: {quest.questName}");

        selectedQuestUI.SetSelected(true);
        UpdateSendButtonState();
    }

    // Quest Resolution Logic
    public void ResolveQuest(KnightData selectedKnight, QuestData selectedQuest/*, RegionData selectedRegion*/)
    {
        string summary = $"Knight {selectedKnight.knightName} completed '{selectedQuest.questName}'\n" +
                 $"Gained {selectedQuest.xpReward} XP, {selectedQuest.goldReward} gold.";

        selectedKnight.GainXP(selectedQuest.xpReward);
        selectedKnightUI.UpdateLevelAndRank();
        questOutcomeUI.ShowOutcome(summary);
        

        this.selectedKnight = null;
        this.selectedQuest = null;

        if (selectedKnightUI != null)
        {
            selectedKnightUI.SetSelected(false);
            selectedKnightUI = null;
        }
        if (selectedQuestUI != null)
        {
            selectedQuestUI.SetSelected(false);
            selectedQuestUI = null;
        }

        UpdateSendButtonState();
    }

    public void PopulateKnightList()
    {
        // Clear old entries
        foreach (Transform child in knightListContent)
        {
            Destroy(child.gameObject);
        }

        // Spawn new knight UI entries
        foreach (KnightData knight in availableKnights)
        {
            GameObject knightInst = Instantiate(knightEntryPrefab, knightListContent);
            KnightEntryUI knightUI = knightInst.GetComponent<KnightEntryUI>();
            if (knightUI != null)
            {
                knightUI.Setup(knight);
                knightUI.OnKnightSelected = HandleKnightSelected;
            }
            else
            {
                Debug.LogError("KnightEntryUI component missing from knightEntryPrefab!", knightInst);
            }
        }
    }

    public void PopulateQuestList()
    {
        // Clear old entries
        foreach (Transform child in questListContent)
        {
            Destroy(child.gameObject);
        }

        // Spawn new quest UI entries
        foreach (QuestData quest in availableQuests)
        {
            GameObject questInst = Instantiate(questEntryPrefab, questListContent);
            QuestUI questUI = questInst.GetComponent<QuestUI>();
            if (questUI != null)
            {
                questUI.Setup(quest);
                questUI.OnQuestSelected = HandleQuestSelected;
            }
            else
            {
                Debug.LogError("QuestUI component missing from QuestPrefab!", questInst);
            }
        }
    }

    private void UpdateSendButtonState()
    {
        sendButton.interactable = (selectedKnight != null && selectedQuest != null);
    }

    public void OnSendButtonClicked()
    {
        if (selectedKnight != null && selectedQuest != null)
        {
            AssignKnightToQuest(selectedKnight, selectedQuest);
        }
    }

    // To Do
    // Calculates success/failure based on:
    // - Knight stats
    // - Quest difficulty/modifiers
    // - Region intel level
    // Outputs result (success, fail, partial).


    // Intel Influence
    // ------------------
    // Optional: modifies randomness based on intel level
    // Could Lerp randomness between full random and deterministic.


    
}
