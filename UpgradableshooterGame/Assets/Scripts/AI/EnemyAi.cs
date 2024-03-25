using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyAi : MonoBehaviour
{
    private NavMeshAgent agent;
    public float HP = 100, damage = 20;
    public Image barHP;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        HP = 100;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            isDead = true;
        }

        if (Crosshair.attacked == true)
        {
            HP -= damage;
        }

        barHP.fillAmount = HP / 100;

        if (!isDead)
        {
            agent.destination = Camera.main.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
