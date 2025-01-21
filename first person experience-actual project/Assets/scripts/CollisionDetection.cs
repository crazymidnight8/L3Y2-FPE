using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController weaponScript;
    public WeaponController wp;
    // public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy" && wp.IsAttacking)
        {
            wp.IsAttacking = false;
            Debug.Log(other.name);
            // Instantiate(HitParticle, new Vector3(other.transform.position.x,transform.position.y,other.transform.position.z), other.transform.rotation);
            other.gameObject.GetComponent<Health>().hp -= weaponScript.damage;
        }
    }
        private void OnTriggerStay(Collider other)
    {
        if(other.tag == "enemy" && wp.IsAttacking)
        {
            wp.IsAttacking = false;
            Debug.Log(other.name);
            // Instantiate(HitParticle, new Vector3(other.transform.position.x,transform.position.y,other.transform.position.z), other.transform.rotation);
            other.gameObject.GetComponent<Health>().hp -= weaponScript.damage;
        }
    }
}
