using System.Collections.Generic;
using UnityEngine;

public enum QuestModifier { }

[CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Objects/QuestData")]
public class QuestData : ScriptableObject
{
    public string id;
    public string questName;
    public int baseDifficulty;
    public string description;
    
    public List<QuestModifier> modifiers;

    public int goldReward;
    public int cpReward;

}
