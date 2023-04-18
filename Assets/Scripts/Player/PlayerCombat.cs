using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int maxLives;
    [SerializeField] private int currentLives;
    [SerializeField] private float normalAttackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform specialAttackPoint;

    [SerializeField] private LayerMask playerLayer;
    private BattleSceneManager battleSceneManager;
    public CharStats character;
    public int currentDamage;
    public int playerIndex;

    private bool canAttack;

    void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();
        currentLives = maxLives;
        canAttack = true;
    }

    public void NormalAttack()
    {
        if (canAttack)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(specialAttackPoint.position, normalAttackRange, playerLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.gameObject != this.gameObject)
                {
                    int damage = Random.Range(character.n_minDamage, character.n_maxDamage + 1);
                    PlayerCombat enemyPlayerCombat = enemy.GetComponent<PlayerCombat>();
                    enemyPlayerCombat.currentDamage += damage;
                    battleSceneManager.uiManager.SetDamage(enemyPlayerCombat.playerIndex, enemyPlayerCombat.currentDamage.ToString());
                    enemyPlayerCombat.Knockback(character.n_knockbackDistance, this.gameObject.GetComponent<Rigidbody2D>());
                }
            }

            if (character.name == "Toni")
            {
                AudioManager.instance.Play("Attack_Galinho");
            }
            else if (character.name == "Vector")
            {
                AudioManager.instance.Play("Attack_Lontra");
            }

            StartCoroutine(AttackCooldown(1));
        }
    }

    private IEnumerator AttackCooldown(int mode)
    {
        canAttack = false;

        if (mode == 1)
        {
            animator.SetBool("Atacando", true);
        }
        else
        {
            animator.SetBool("Especial", true);
        }

        yield return new WaitForSeconds(.2f);

        if (mode == 1)
        {
            animator.SetBool("Atacando", false);
        }
        else
        {
            animator.SetBool("Especial", false);
        }

        canAttack = true;
    }

    public void SpecialAttack()
    {

        if (canAttack)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, normalAttackRange, playerLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.gameObject != this.gameObject)
                {
                    int damage = Random.Range(character.s_minDamage, character.s_maxDamage + 1);
                    PlayerCombat enemyPlayerCombat = enemy.GetComponent<PlayerCombat>();
                    enemyPlayerCombat.currentDamage += damage;
                    battleSceneManager.uiManager.SetDamage(enemyPlayerCombat.playerIndex, enemyPlayerCombat.currentDamage.ToString());
                    enemyPlayerCombat.Knockback(character.s_knockbackDistance, this.gameObject.GetComponent<Rigidbody2D>());
                }
            }

            if (character.name == "Toni")
            {
                AudioManager.instance.Play("Attack_Galinho");
            }
            else if (character.name == "Vector")
            {
                AudioManager.instance.Play("Attack_Lontra");
            }

            StartCoroutine(AttackCooldown(2));
        }

        return;
    }

    public void Knockback(int distance, Rigidbody2D enemy_rb)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float knockback = ((currentDamage / 10) + ((currentDamage * distance) / 20));
        Vector2 diff = transform.position - enemy_rb.transform.position;
        diff = diff.normalized * knockback;
        diff.y = 7.5f;

        if (character.name == "Toni")
        {
            AudioManager.instance.Play("Damage_Galinho");
        }
        else if (character.name == "Vector")
        {
            AudioManager.instance.Play("Damage_Lontra");
        }

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

        currentDamage = 0;
        battleSceneManager.uiManager.SetLives(playerIndex, currentLives);
        battleSceneManager.uiManager.SetDamage(playerIndex, currentDamage.ToString());
        battleSceneManager.RespawnPlayer(this.gameObject, playerIndex);
    }
}
