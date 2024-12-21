using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{

   
    //public Transform Player;
    character_states stats;
    NavMeshAgent agent;
    Animator anim;
    public float attackRadius = 5;
    bool canAttack=true;
    float attackCooldown = 3f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<character_states>();
    }

    void Update()
    {
        anim.SetFloat("speed",agent.velocity.magnitude);
        float distance = Vector3.Distance(transform.position,LevelManager.instance.player.position);
        if (distance < attackRadius)
        {
            agent.SetDestination(LevelManager.instance.player.position);
       if (distance <= agent.stoppingDistance)
            {
                if(canAttack)
                {
                    StartCoroutine(cooldowm());
                    //play attack animation
                    anim.SetTrigger("attack");
                }
            }
        }

    }

    IEnumerator cooldowm()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true; 
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {  //Debug.Log("Player Contacted");
            stats.ChangeHealth(-other.GetComponentInParent<character_states>().power);
            // Destroy(gameObject);
        }
    }

    public void DamageManager()
    {
     LevelManager.instance.player.GetComponent<character_states>().ChangeHealth(-stats.power);
    }

}

