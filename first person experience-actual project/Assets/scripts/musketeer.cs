using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class musketeer : MonoBehaviour
{
    public int damage, damageAmount;

    public float attackDelay, attackRate, attackDistance, health;

    GameObject playerObject;


    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("enemy");
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Time.time > attackDelay)
        {
            if(Vector3.Distance(playerObject.transform.position, transform.position) <= attackDistance)
            {
                Attack();
            }
        }
    }

    void Move()
    {
        navAgent.destination = playerObject.transform.position;
    }

    void Attack()
    {
        playerObject.GetComponent<Health>().hp -= damageAmount;
        attackDelay = Time.time + attackRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.GetComponent<Health>().hp -= damage;
        }
    }
}
