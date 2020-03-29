using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject nozzle, bulletHolePrefab;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private int damage;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private AudioClip gunClip;

    private AudioSource source;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(nozzle.transform.position, nozzle.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    ITakeDamage damagable = hit.collider.GetComponent<ITakeDamage>();
                    if (damagable != null)
                        damagable.TakeDamage(damage);
                }
            }
            if (Physics.Raycast(nozzle.transform.position, nozzle.transform.forward, out hit, Mathf.Infinity, mask))
            {
                Quaternion rot = Quaternion.LookRotation(hit.normal);
                Instantiate(bulletHolePrefab, hit.point, rot);
            }
            else
            {
                //Debug.Log("Did not Hit");
            }
            anim.Play("PistolShoot", -1, 0);
            source.PlayOneShot(gunClip);
        }
    }
}
