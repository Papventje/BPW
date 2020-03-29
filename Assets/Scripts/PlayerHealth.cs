using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int health;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject onDeath;

    private void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Instantiate(onDeath, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        slider.value = health;
    }
}
