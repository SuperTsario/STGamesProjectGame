using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyScript1 : MonoBehaviour
{
    public Rigidbody2D rbEnm;
    public int damage = 10;
    void Start()
    {
        rbEnm = GetComponent<Rigidbody2D>();
        gameObject.tag = "Enemy";
    }


    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                playerHealth.TakeDamage(damage, knockbackDirection);
            }
        }
        
    }
}
