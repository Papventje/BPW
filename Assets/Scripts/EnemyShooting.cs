using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject bullet, muzzle;

    [SerializeField]
    private float fireRate = 1f, range = 50f;

    [SerializeField]
    private AudioClip clip;

    private float nextFire;

    public bool canShoot = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist < range && Time.time > nextFire && canShoot)
            {
                nextFire = Time.time + fireRate;

                GameObject enemyBullet = Instantiate(bullet, muzzle.transform.position, transform.rotation);
                Vector3 targetDirection = player.transform.position - transform.position;
                enemyBullet.transform.rotation = Quaternion.LookRotation(targetDirection);

                AudioSource.PlayClipAtPoint(clip, transform.position, .2f);
            }
        }
    }
}
