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
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {

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
                enemyPlayerCombat.Knockback(character.n_knockbackDistance);
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

    public void Knockback(int distance)
    {
        float knockback = ((currentDamage / 10) + ((currentDamage * distance) / 20));
        Debug.Log(knockback);
    }

    public void Die()
    {
        currentLives -= 1;

        if (currentLives <= 0)
        {
            if (playerIndex == 1)
            {
                battleSceneManager.EndBattle(2);
            }
            else if (playerIndex == 2)
            {
                battleSceneManager.EndBattle(1);
            }
            return;
        }

        battleSceneManager.RespawnPlayer(this.gameObject, playerIndex);
    }
}
