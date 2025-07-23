using System.Collections.Generic;
using UnityEngine;

public enum KnightRank
{
    Esquire,
    MercenaryKnight,
    KnightErrant,
    KnightCaptain,
    KnightCommander
}

[CreateAssetMenu(fileName = "KnightData", menuName = "Scriptable Objects/KnightData")]
public class KnightData : ScriptableObject
{   

    [Header("Identity")]
    public string id;
    public string knightName;
    public Sprite portrait;

    [Header("Leveling")]
    public int level = 1;
    public int experience = 0;

    [SerializeField] public int levelRate = 20;

    public int GetXPThresholdForCurrentLevel()
    {
        return 100 + (level * levelRate);
    }

    public void GainXP(int amount)
    {
        while (amount > 0 && level < 100)
        {
            int xpToLevel = GetXPThresholdForCurrentLevel();

            if (experience + amount < xpToLevel)
            {
                experience += amount;
                break;
            }

            amount -= (xpToLevel - experience);
            experience = 0;
            level++;
        }
    }

    public KnightRank Rank
    {
        get
        {
            if (level <= 25) return KnightRank.Esquire;
            if (level <= 50) return KnightRank.MercenaryKnight;
            if (level <= 70) return KnightRank.KnightErrant;
            if (level <= 90) return KnightRank.KnightCaptain;
            return KnightRank.KnightCommander;
        }
    }

    [Header("Attributes")]
    [Range(0, 100)] public int strength;
    [Range(0, 100)] public int stealth;
    [Range(0, 100)] public int charisma;
    [Range(0, 100)] public int tactics;
    // [Range(0, 100)] public int pride; high pride wont accept certain quests? or make function of overall knight level so high level knight wont perform low level missions?...

    [Header("Traits")]
    public List<KnightTraitData> traits;    
}
