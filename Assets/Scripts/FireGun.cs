using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {

    public AudioSource gunshot;

    private GameObject bullet;
    private float bulletSpeed = 1000f;
    private float bulletLife = 5f;

    protected void Start()
    {
        bullet = transform.Find("Bullet").gameObject;
        bullet.SetActive(false);
    }

    public void FireBullet()
    {
        gunshot.Play();
        GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
        bulletClone.SetActive(true);
        //my solution to set the initial direction of bullet to determine where the spawned balls have to go
        bulletClone.GetComponent<Info>().setX(bullet.transform.forward.x);
        bulletClone.GetComponent<Info>().setZ(bullet.transform.forward.z);

        Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
        rb.AddForce(bullet.transform.forward * bulletSpeed);
        //Debug.Log("bulletinitial: " + bullet.transform.forward);
        Destroy(bulletClone, bulletLife);
    }
}
