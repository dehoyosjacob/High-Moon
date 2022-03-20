using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Detected player");
        HealthBar playerHealth = other.gameObject.GetComponent<HealthBar>();

        if (playerHealth != null)
        {
            Debug.Log("Found component");
            playerHealth.TakeDamage(5);
            Destroy(this.gameObject);
        }
    }
}
