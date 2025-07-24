using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KnightEntryUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI knightNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TextMeshProUGUI statsText;
    [SerializeField] private Image highlightImage;


    private KnightData knightData;

    private string GetRankDisplayName(KnightRank rank)
    {
        switch (rank)
        {
            case KnightRank.Esquire: return "Esquire";
            case KnightRank.MercenaryKnight: return "Mercenary Knight";
            case KnightRank.KnightErrant: return "Knight Errant";
            case KnightRank.KnightCaptain: return "Knight Captain";
            case KnightRank.KnightCommander: return "Knight Commander";
            default: return rank.ToString();
        }
    }

    public System.Action<KnightData, KnightEntryUI> OnKnightSelected;
    public void Setup(KnightData data)
    {
        knightData = data;

        if (knightNameText == null || rankText == null || statsText == null)
        {
            Debug.LogError("UI references are missing in KnightEntryUI!", this);
            return;
        }

        knightNameText.text = $"{data.knightName}";
        rankText.text = GetRankDisplayName(data.Rank);

        //xpSlider.maxValue = data.GetXPThresholdForCurrentLevel();
        //xpSlider.value = data.experience;

        statsText.text = $"STR: {data.strength} | STL: {data.stealth} | CHA: {data.charisma} | TAC: {data.tactics}";
    }

    public void UpdateLevelAndRank()
    {
        //levelText.text = $"Level {knightData.level}";
        rankText.text = GetRankDisplayName(knightData.Rank);
        //statsText.text = $"STR: {data.strength} | STL: {data.stealth} | CHA: {data.charisma} | TAC: {data.tactics}";
    }

    public void OnClick()
    {
        OnKnightSelected?.Invoke(knightData, this);
    }

    public void SetSelected(bool isSelected)
    {
        if (highlightImage == null)
        {
            Debug.LogWarning("Highlight Image is not assigned in KnightEntryUI!", this);
            return;
        }

        highlightImage.color = isSelected ? Color.yellow : Color.white;
    }
}
