using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float cooldownTime = 2f;
    [SerializeField] float deathTime = 1f;
    [SerializeField] Animator enemyAnim;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject healthPickup;
    [SerializeField] GameObject ammoPickup;

    int enemyHealth;
    float rNum;
    float distanceToPlayer;
    bool gunReady;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 20;
        gunReady = true;
        GetComponent<AIPath>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (enemyHealth <= 0 && isAlive)
        {
            isAlive = false;
            rNum = Random.Range(0f, 3f);
            SelectDrop(rNum);
            enemyAnim.SetBool("isDead", true);
            Debug.Log("Killed enemy");
            Destroy(gameObject, 1f);
            enemyAnim.SetBool("isWalking", false);
            GetComponent<AIPath>().enabled = false;

        }

        //enemyAnim.SetBool("isDead", false);

        distanceToPlayer = Vector2.Distance(this.transform.position, player.transform.position);

        if(distanceToPlayer <= 20)
        {
            FacePlayer();
            GetComponent<AIPath>().enabled = true;
            enemyAnim.SetBool("isWalking", true);
        }

        else if(distanceToPlayer > 20 && isAlive)
        {
            GetComponent<AIPath>().enabled = false;
            enemyAnim.SetBool("isWalking", false);
        }

        if(distanceToPlayer <= 10 && gunReady == true && isAlive)
        {
            //Debug.Log("Player in range");
            Shoot();
            enemyAnim.SetBool("isWalking", false);

        }
    }

    public void Damage(int dmg)
    {
        enemyHealth -= dmg;
    }

    private void FacePlayer()
    {
        Vector2 direction = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        Instantiate(bullet, this.transform.position, this.transform.rotation);
        StartCoroutine(GunCoolDown(cooldownTime));
    }


    IEnumerator GunCoolDown(float seconds)
    {
        gunReady = false;

        yield return new WaitForSeconds(seconds);

        gunReady = true;
    }

    private void SelectDrop(float selection)
    {
        if (selection < 1)
        {
            return;
        }

        else if (selection >= 1 && selection < 2)
        {
            Instantiate(healthPickup, this.transform.position, this.transform.rotation);
        }

        else if (selection >= 2 && selection < 3)
        {
            Instantiate(ammoPickup, this.transform.position, this.transform.rotation);
        }
    }
}
