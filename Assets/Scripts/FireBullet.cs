using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.H) && player != null)
        {
            FireGun();
            Debug.Log("Fired the gun!");
        }
    }

    private void FireGun()
    {
        Instantiate(bullet, bulletSpawn.position, transform.rotation);
    }
}
