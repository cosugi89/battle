using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text valueText;
    public Button button;

    private Card cardData;
    private BattleManager battleManager;

    public void Setup(Card card, BattleManager manager)
    {
        cardData = card;
        battleManager = manager;

        nameText.text = card.Name;
        valueText.text = $"{card.Type} ({card.Value})";

        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        battleManager.OnCardPlayed(cardData);
    }
}
