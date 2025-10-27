using UnityEngine;

/// <summary>
/// 敵キャラクターを制御
/// </summary>
public class EnemyController : MonoBehaviour
{
    public int MaxHP = 30;
    public int CurrentHP;

    private void Awake()
    {
        CurrentHP = MaxHP;
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        Debug.Log($"Enemy took {damage} damage. HP: {CurrentHP}");
    }

    public bool IsDead()
    {
        return CurrentHP <= 0;
    }

    public void Attack(PlayerController player)
    {
        int damage = 6;
        player.TakeDamage(damage);
        Debug.Log($"Enemy attacks! {damage} damage dealt.");
    }
}
