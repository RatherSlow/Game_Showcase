using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestOutcomeUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI summaryText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {        
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(Hide);
        }

        Hide(); 
    }

    public void ShowOutcome(string summary)
    {
        summaryText.text = summary;
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}