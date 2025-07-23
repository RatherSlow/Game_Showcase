using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    // References
    //[SerializeField] private List<RegionData> availableRegions;
    [SerializeField] private List<KnightData> availableKnights;
    [SerializeField] private List<QuestData> availableQuests;

    [SerializeField] private GameObject questMapPanel;
    [SerializeField] private Transform questDetailPanel;
    [SerializeField] private Transform regionContainer;

    [SerializeField] private GameObject knightListPanel;
    [SerializeField] private Transform knightListContent;
    [SerializeField] private GameObject knightEntryPrefab;

    [SerializeField] private GameObject questEntryPrefab;
    [SerializeField] private Transform questListContent;

    [SerializeField] private GameObject questOutcomePanel;
    [SerializeField] private GameObject topBarPanel;

    private void Start()
    {
        PopulateKnightList();
        PopulateQuestList();
    }


    // Selected Units
    private RegionData selectedRegion;
    private KnightData selectedKnight;
    private QuestData selectedQuest;
    // Currently selected knight and quest for assignment.

    private void HandleKnightSelected(KnightData knight)
    {
        selectedKnight = knight;
        Debug.Log($"Selected knight: {knight.knightName}");        
    }

    // Assignment Logic
    public void AssignKnightToQuest(KnightData knight, QuestData quest)
    {
        selectedKnight = knight;
        selectedQuest = quest;

        ResolveQuest(selectedKnight, selectedQuest, selectedRegion);
    }
    // Method to assign knight to a quest
    // Triggers resolution, adjusts stats, updates outcomes.

    private void HandleQuestSelected(QuestData quest)
    {
        selectedQuest = quest;
        Debug.Log($"Selected quest: {quest.questName}");
    }

    // Quest Resolution Logic
    public void ResolveQuest(KnightData selectedKnight, QuestData selectedQuest, RegionData selectedRegion)
    {

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
            knightUI.Setup(knight);
                        
            knightUI.OnKnightSelected = HandleKnightSelected;
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
            questUI.Setup(quest);

            questUI.OnQuestSelected = HandleQuestSelected;
        }
    }

    // Calculates success/failure based on:
    // - Knight stats
    // - Quest difficulty/modifiers
    // - Region intel level
    // Outputs result (success, fail, partial).


    // Intel Influence
    // ------------------
    // Optional: modifies randomness based on intel level
    // Could Lerp randomness between full random and deterministic.


    // UI Feedback
    // ------------------
    // Triggers UI updates, shows results, resets selection, etc.
}
