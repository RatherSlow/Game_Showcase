using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI questNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI difficultyText;
    [SerializeField] private TextMeshProUGUI rewardsText;

    private QuestData questData;

    public System.Action<QuestData> OnQuestSelected;

    public void Setup(QuestData data)
    {
        questData = data;

        questNameText.text = data.questName;
        descriptionText.text = data.description;
        difficultyText.text = $"Difficulty: {data.baseDifficulty}";
        rewardsText.text = $"Gold: {data.goldReward} | XP: {data.xpReward}";
    }

    public void OnClick()
    {
        OnQuestSelected?.Invoke(questData);
    }
}