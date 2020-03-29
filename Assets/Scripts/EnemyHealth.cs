using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int health;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject drop;

    [SerializeField]
    private GameObject particle;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();

        slider.maxValue = health;
        slider.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(particle, transform.position, transform.rotation);
            Instantiate(drop, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        slider.value = health;
    }

}
