using System.Collections.Generic;
using UnityEngine;

public enum KnightTrait { }

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
    public string id;
    public string knightName;

    public int level = 1;

    [Range(0, 100)] public int strength;
    [Range(0, 100)] public int stealth;
    [Range(0, 100)] public int charisma;
    [Range(0, 100)] public int tactics;
    // [Range(0, 100)] public int pride; high pride wont accept certain quests? or make function of overall knight level so high level knight wont perform low level missions?...

    public List<KnightTrait> traits;

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
}
