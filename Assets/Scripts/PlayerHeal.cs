using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] HealthBar pHealth;
    [SerializeField] int heal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement pMove = other.gameObject.GetComponent<PlayerMovement>();

        if (pMove != null)
        {
            pHealth.HealDamage(heal);
            Destroy(gameObject);
        }
    }
}
