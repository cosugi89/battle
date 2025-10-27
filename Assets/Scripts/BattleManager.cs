using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    [Header("References")]
    public PlayerController player;
    public EnemyController enemy;
    public Transform handArea; // カードを並べるUIエリア
    public GameObject cardPrefab; // カードUIのPrefab

    private List<Card> hand = new List<Card>();

    private void Start()
    {
        Debug.Log("=== Battle Start ===");
        StartTurn();
    }

    private void StartTurn()
    {
        Debug.Log("Player's turn!");
        DrawHand();
    }

    private void DrawHand()
    {
        ClearHand();

        // 仮の3枚を生成
        hand.Add(new Card("Strike", 1, 8, CardType.Attack));
        hand.Add(new Card("Defend", 1, 5, CardType.Defend));
        hand.Add(new Card("Strike+", 2, 12, CardType.Attack));

        foreach (Card card in hand)
        {
            GameObject cardObj = Instantiate(cardPrefab, handArea);
            CardView view = cardObj.GetComponent<CardView>();
            view.Setup(card, this);
        }
    }

    private void ClearHand()
    {
        foreach (Transform child in handArea)
        {
            Destroy(child.gameObject);
        }
        hand.Clear();
    }

    // ← CardViewから呼ばれる
    public void OnCardPlayed(Card card)
    {
        Debug.Log($"Card Played: {card.Name}");

        card.Use(player, enemy);

        if (enemy.IsDead())
        {
            Debug.Log("Enemy defeated!");
        }
        else
        {
            // 敵ターンに移行
            EnemyTurn();
        }

        ClearHand(); // 手札をリセット
    }

    private void EnemyTurn()
    {
        Debug.Log("Enemy's turn!");
        enemy.Attack(player);

        if (player.IsDead())
        {
            Debug.Log("Player defeated...");
        }
        else
        {
            StartTurn(); // 次ターンへ
        }
    }
}
