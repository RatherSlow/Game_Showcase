using System.Collections.Generic;
using UnityEngine;

public static class QuestGenerator
{
    public static List<QuestData> GenerateForRegion(RegionData region)
    {
        List<QuestData> generatedQuests = new List<QuestData>();

        Random.InitState(region.questSeed);

        for (int i = 0; i < region.maxGeneratedQuests; i++)
        {
            QuestData quest = ScriptableObject.CreateInstance<QuestData>();

            quest.questType = QuestType.Procedural;

            quest.id = $"{region.regionName}_proc_{i}";
            quest.questName = $"[Proc] {region.regionName} Mission #{Random.Range(1000, 9999)}";
            quest.baseDifficulty = Random.Range(region.minDifficulty, region.maxDifficulty + 1);
            quest.description = $"Intel suggests a mission of interest in {region.regionName}.";

            // quest.modifiers = new List<QuestModifier>
            // {
            //     insert modifiers here
            // };

            quest.goldReward = quest.baseDifficulty * 10;
            quest.xpReward = quest.baseDifficulty * 10;

            generatedQuests.Add(quest);
        }

        return generatedQuests;
    }
}