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
        else
        {
            target = null;
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().ResetPath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
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

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectWithTag("enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
