using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    // References
    [SerializeField] private List<RegionData> availableRegions;
    [SerializeField] private List<KnightData> availableKnights;
    [SerializeField] private List<QuestData> availableQuests;

    [SerializeField] private GameObject questMapPanel;
    [SerializeField] private Transform questDetailPanel;
    [SerializeField] private Transform regionContainer;

    [SerializeField] private GameObject knightListPanel;
    [SerializeField] private Transform knightListContent;

    [SerializeField] private GameObject questOutcomePanel;
    [SerializeField] private GameObject topBarPanel;

    // Selected Units
    private RegionData selectedRegion;
    private KnightData selectedKnight;
    private QuestData selectedQuest;
    // Currently selected knight and quest for assignment.


    // Assignment Logic
    public void AssignKnightToQuest(KnightData knight, QuestData quest)
    {
        selectedKnight = knight;
        selectedQuest = quest;

        ResolveQuest(selectedKnight, selectedQuest, selectedRegion);
    }
    // Method to assign knight to a quest
    // Triggers resolution, adjusts stats, updates outcomes.


    // Quest Resolution Logic
    public void ResolveQuest(KnightData selectedKnight, QuestData selectedQuest, RegionData selectedRegion)
    {

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
