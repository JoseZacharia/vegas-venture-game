using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingTrapHealth_1 : MonoBehaviour
{
    public float maxHealth;

    healthbarBehaviour_1 healthBar;

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar = gameObject.GetComponentInChildren<healthbarBehaviour_1>();
        healthBar.setHealth(currentHealth, maxHealth);
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth--;
            healthBar.setHealth(currentHealth, maxHealth);
            if (currentHealth <= 0)
                Destroy(gameObject);
        }


    }
}
