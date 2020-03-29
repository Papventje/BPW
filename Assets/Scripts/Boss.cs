using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private GameObject mini;

    private void Update()
    {
        transform.Rotate(0, 0, .1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TurretBullet")
        {
            Instantiate(mini, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
