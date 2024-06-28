using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth = 0;
    public float invincibilityDuration = 5.0f;
    public float knockbackForce = 5.0f;
    private bool isInvincible = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage, Vector2 knockbackDirection)
    {
        if (isInvincible)
            return;

        CurrentHealth -= damage;
        rb.velocity = Vector2.zero;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("Player died.");
            // Add code to handle player death here, if needed
        }
        StartCoroutine(BecomeInvincible());
    }

    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;
        //animation of invinsibility
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;

    }
}