using UnityEngine;

[System.Serializable]
public class Card
{
    public string Name;
    public int Cost;
    public int Value;
    public CardType Type;

    public Card(string name, int cost, int value, CardType type)
    {
        Name = name;
        Cost = cost;
        Value = value;
        Type = type;
    }

    public void Use(PlayerController player, EnemyController enemy)
    {
        switch (Type)
        {
            case CardType.Attack:
                enemy.TakeDamage(Value);
                Debug.Log($"{Name} used! Dealt {Value} damage to enemy!");
                break;
            case CardType.Defend:
                player.GainBlock(Value);
                Debug.Log($"{Name} used! Gained {Value} block!");
                break;
        }
    }
}

public enum CardType
{
    Attack,
    Defend
}

