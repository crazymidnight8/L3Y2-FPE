using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class musketeer : MonoBehaviour
{
    public enemy enemy;
    public int Level;
    public SkillScriptableObject[] Skills;

    public int damage, damageAmount;

    public const string Jump = "Jump";
    public const string Landed = "Landed";

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

        for (int i = 0; i < Skills.Length; i++)
        {
            if (Skills[i].CanUseSkill(this, enemy, Level))
            {
                Skills[i].UseSkill(this, enemy);
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
            Destroy(gameObject);
        }
    }
}
