using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20, destroyTime;

    [SerializeField]
    private int damage = 10;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            ITakeDamage damagable = other.gameObject.GetComponent<ITakeDamage>();
            if (damagable != null)
                damagable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
