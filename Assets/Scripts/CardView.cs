using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private Button _button;

    private Card cardData;
    private BattleManager battleManager;

    public void Setup(Card card, BattleManager manager)
    {
        cardData = card;
        battleManager = manager;

        _nameText.text = card.Name;
        _valueText.text = $"{card.Type} ({card.Value})";

        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        battleManager.OnCardPlayed(cardData);
    }
}
