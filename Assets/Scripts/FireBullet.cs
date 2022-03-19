using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] PlayerMovement player;
    [SerializeField] Level01Controller lControl;
    [SerializeField] AudioSource gunAudio;
 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.H) && player != null)
        {
            if(lControl.bullets > 0)
            {
                FireGun();
                Debug.Log("Fired the gun!");
            }

            else
            {
                Debug.Log("Out of ammo!");
            }
            
        }
    }

    private void FireGun()
    {
        gunAudio.Play();
        lControl.bulletAdjust(false, 1);
        Instantiate(bullet, bulletSpawn.position, transform.rotation);
    }
}
