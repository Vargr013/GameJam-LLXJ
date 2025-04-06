using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 20;
    private Collider2D attackColider;

    private void Awake()
    {
        attackColider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //See if the player can be hit 
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            //Hit the target 
            damageable.Hit(attackDamage);
        }
    }
}
