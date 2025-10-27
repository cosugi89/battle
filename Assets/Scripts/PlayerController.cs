using UnityEngine;

/// <summary>
/// プレイヤーキャラクターを制御
/// </summary>
public class PlayerController : MonoBehaviour
{
    public int MaxHP = 50;
    public int CurrentHP;
    public int Block;

    private void Awake()
    {
        CurrentHP = MaxHP;
    }

    public void TakeDamage(int damage)
    {
        int effectiveDamage = Mathf.Max(0, damage - Block);
        CurrentHP -= effectiveDamage;
        Block = Mathf.Max(0, Block - damage);

        Debug.Log($"Player took {effectiveDamage} damage. HP: {CurrentHP}");
    }

    public void GainBlock(int amount)
    {
        Block += amount;
        Debug.Log($"Player gained {amount} block. Total Block: {Block}");
    }

    public bool IsDead()
    {
        return CurrentHP <= 0;
    }
}

