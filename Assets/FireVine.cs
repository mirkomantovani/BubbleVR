using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireVine : MonoBehaviour
{
    public AudioSource laserSound;
    private GameObject bullet;
    //public Animator vineAnim;
    //in class pc 75f was perfect, maybe with fixed update it works on both
    private float bulletSpeed = 500f;
    private float bulletLife = 5f;

    protected void Start()
    {
        bullet = transform.Find("Vine").gameObject;
        bullet.SetActive(false);
    }

    public void FireBullet()
    {
        laserSound.Play();
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
