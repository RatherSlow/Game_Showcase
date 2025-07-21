using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RegionData", menuName = "Scriptable Objects/RegionData")]
public class RegionData : ScriptableObject
{
    public string regionName;
    public int intelLevel;

    public Sprite regionIcon;
    public Color themeColor;

    [TextArea] public string regionDescription;
    // public string factionControl; other groups such as bandits, saxons, etc?

    // Optional themes for procedural generation
    public string regionTheme;
    public int minDifficulty;
    public int maxDifficulty;

    // Handcrafted quests specific to this region
    public List<QuestData> storyQuests;

    // For procedural generation:
    public int questSeed;
    public int maxGeneratedQuests;
}
