using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class musketeer : MonoBehaviour
{
    public int damage, damageAmount;

    public float attackDelay, attackRate, attackDistance, health;

    // GameObject playerObject;


    NavMeshAgent navAgent;

    MusketeerSkillActivate skillScript;

    bool active;

    // Start is called before the first frame update
    void Start()
    {
        // playerObject = GameObject.FindGameObjectWithTag("enemy");
        skillScript = transform.GetComponent<MusketeerSkillActivate>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skillScript.target != null)
        {
            Move();

            if (!active)
            {
                StartCoroutine(Attack());
            }
        }

        // if(Time.time > attackDelay)
        // {
        //     if(Vector3.Distance(playerObject.transform.position, transform.position) <= attackDistance)
        //     {
        //         Attack();
        //     }
        // }
    }

    void Move()
    {
        navAgent.destination = skillScript.target.transform.position;
    }

    // void Attack()
    // {
    //     playerObject.GetComponent<Health>().hp -= damageAmount;
    //     attackDelay = Time.time + attackRate;
    // }

    IEnumerator Attack()
    {
        active = true;

        skillScript.target.GetComponent<Health>().hp -= damageAmount;

        yield return new WaitForSeconds(attackRate);
        active = false;
    }
}
