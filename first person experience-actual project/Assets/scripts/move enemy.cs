using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveenemy : MonoBehaviour
{
    public int damage;

    public float damageAmount, attackDelay, attackRate, attackDistance, health;

    GameObject playerObject;


    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("castle");
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
        navAgent.destination = playerObject.transform.position;
    }

    // void Attack()
    // {
    //     playerObject.GetComponent<playerhealth>().health -= damageAmount;
    //     attackDelay = Time.time + attackRate;
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("castle"))
        {
            other.gameObject.GetComponent<castle>().hp -= damage;
            Destroy(gameObject);
        }
    }
}
