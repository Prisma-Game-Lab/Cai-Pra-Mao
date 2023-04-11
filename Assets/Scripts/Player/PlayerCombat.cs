using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int maxLives;
    [SerializeField] private int currentLives;
    [SerializeField] private float normalAttackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;
    private BattleSceneManager battleSceneManager;
    public CharStats character;
    public int currentDamage;
    public int playerIndex;

    void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();
        currentLives = maxLives;

    }

    public void NormalAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, normalAttackRange, playerLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject != this.gameObject)
            {
                int damage = Random.Range(character.n_minDamage, character.n_maxDamage + 1);
                PlayerCombat enemyPlayerCombat = enemy.GetComponent<PlayerCombat>();
                enemyPlayerCombat.currentDamage += damage;
                enemyPlayerCombat.Knockback(character.n_knockbackDistance, this.gameObject.GetComponent<Rigidbody2D>());
            }
        }
    }

    public void ToniSpecialAttack()
    {
        int damage = Random.Range(character.s_minDamage, character.s_maxDamage + 1);
        return;
    }

    public void VectorSpecialAttack()
    {
        int damage = Random.Range(character.s_minDamage, character.s_maxDamage + 1);
        return;
    }

    public void Knockback(int distance, Rigidbody2D enemy_rb)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float knockback = ((currentDamage / 10) + ((currentDamage * distance) / 20));
        Vector2 diff = transform.position - enemy_rb.transform.position;
        diff = diff.normalized * knockback;
        diff.y = 7.5f;
        rb.AddForce(diff, ForceMode2D.Impulse);
    }

    public void Die()
    {
        currentLives -= 1;

        if (currentLives <= 0)
        {
            if (character.name == "Toni")
            {
                battleSceneManager.EndBattle("Vector");
            }
            else if (character.name == "Vector")
            {
                battleSceneManager.EndBattle("Toni");
            }
            return;
        }

        battleSceneManager.RespawnPlayer(this.gameObject, playerIndex);
        currentDamage = 0;
    }
}
