using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RegionData", menuName = "Scriptable Objects/RegionData")]
public class RegionData : ScriptableObject
{
    public string regionName;
    public int intelLevel;

    // Optional themes for procedural generation
    public string regionTheme;
    public int minDifficulty;
    public int maxDifficulty;

    // Handcrafted quests specific to this region
    public List<QuestData> handcraftedQuests;
}
