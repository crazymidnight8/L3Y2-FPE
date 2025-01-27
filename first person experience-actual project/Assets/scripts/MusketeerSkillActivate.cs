using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusketeerSkillActivate : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        if (target != null)
        {
            Debug.Log("inRange");
            // transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (target == null)
            {
                target = other.gameObject;
            }
        }
    }
}
