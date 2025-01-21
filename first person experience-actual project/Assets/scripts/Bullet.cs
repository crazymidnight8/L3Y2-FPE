using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigidbody;
    public float bulletSpeed;
    public int bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            other.transform.GetComponent<Health>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
