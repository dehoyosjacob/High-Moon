using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage(int dmg)
    {
        enemyHealth -= dmg;
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet collided");
        if(other.CompareTag("Bullet"))
        {
            Damage(5);
        }
    }*/
}
