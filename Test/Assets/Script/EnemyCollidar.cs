using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollidar : MonoBehaviour
{
    CharacterStats stats;
    //public Transform Player;
    NavMeshAgent agent;
    Animator anim;
    public float attackraduis = 5;

    bool canAttack = true;
    float attackCooldown = 3f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed",agent.velocity.magnitude);
        float distance = Vector3.Distance(transform.position, LevelManger.instance.Player.position);
        if (distance < attackraduis)
        {
            agent.SetDestination(LevelManger.instance.Player.position);
            if(distance <= agent.stoppingDistance)
            {
                if(canAttack)
                {
                    StartCoroutine(cooldown());
                    anim.SetTrigger("Attack");
                    //play attack animation
                }

            }
        }
    }

    IEnumerator cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player Contacted!");
            stats.ChangeHealth(-other.GetComponentInParent<CharacterStats>().power);
            //Destroy(gameObject);
        }
    }
    public void DamagePlayer()
    {
        LevelManger.instance.Player.GetComponent<CharacterStats>().ChangeHealth(-stats.power);
    }
}
