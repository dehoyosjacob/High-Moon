using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Detected enemy");

        EnemyController eControl = other.transform.gameObject.GetComponent<EnemyController>();

        if (eControl != null)
        {
            Debug.Log("Found component");
            eControl.Damage(5);
            Destroy(this.gameObject);
        }
    }
}
