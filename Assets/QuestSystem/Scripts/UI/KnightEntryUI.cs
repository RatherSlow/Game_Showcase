using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KnightEntryUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI knightNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TextMeshProUGUI statsText;

    private KnightData knightData;

    public System.Action<KnightData> OnKnightSelected;
    public void Setup(KnightData data)
    {
        knightData = data;

        knightNameText.text = $"{data.knightName} ({data.Rank})";
        levelText.text = $"Level {data.level}";
                
        xpSlider.maxValue = data.GetXPThresholdForCurrentLevel();
        xpSlider.value = data.experience;

        statsText.text = $"STR: {data.strength} | STL: {data.stealth} | CHA: {data.charisma} | TAC: {data.tactics}";
    }
    
    public void OnClick()
    {
        OnKnightSelected?.Invoke(knightData);
    }
}
