using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyAi : MonoBehaviour
{
    private NavMeshAgent agent;
    public ShopItemSD weaponDamage;
    public float HP = 100, attackDamage = 5, shootingDamage = 20, attackRange = 3, attackTimer = 3;
    private float distance, attackTimer_Script = 3;
    public GameObject player, enemy;
    public Image barHP;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        attackTimer_Script = attackTimer;
        isDead = false;
        HP = 100;
        agent = GetComponent<NavMeshAgent>();
        enemy = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBehaviour();
        DealDamage();
    }
    //public void TakeDamage(float damage) => HP -= damage;

    private void HealthBehaviour()
    {
        if (HP <= 0)
        {
            ShopManager Coin = new ShopManager();
            ShopManager.coins += 10;
            Destroy(gameObject);
        }
        barHP.fillAmount = HP / 100;
        if (HP <= 0)
        {
            isDead = true;
        }
        if (!isDead)
        {
            agent.destination = Camera.main.transform.position;
        }
    }

    private void DealDamage()
    {
        if(PositionSwitch.camManager == 0) player = GameObject.FindWithTag("Player");
        else if(PositionSwitch.camManager == 1) player = GameObject.FindWithTag("Player2");

        distance = Vector3.Distance(enemy.transform.position, player.transform.position);

        if(distance < attackRange)
        {
            attackTimer_Script -= Time.deltaTime;
            if(attackTimer_Script <= 0)
            {
                PlayerManager.playerHealth -= attackDamage;
                attackTimer_Script = attackTimer;
            }
        }
    }
}
