using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour

{
    [Tooltip("Replace this bullet with your own object")] public GameObject Bullet;
    [Tooltip("The point where the bullet is spawned")] public GameObject firePoint;
    // Update is called once per frame
    public float fireRate = 0.5f;
    private float nextFire = 0.5f;

    void Update()
    {
        if(Input.GetButtonDown("Fire2") && Time.time > nextFire)
        {
            //Fires on right mouse button with cooldown
            nextFire = Time.time + fireRate;
            GameObject bulletClone = Instantiate(Bullet, firePoint.transform.position, firePoint.transform.rotation);
            Destroy(bulletClone, 5f); //deletes the bullet after a certain amount of time. 
        }
    }
}
