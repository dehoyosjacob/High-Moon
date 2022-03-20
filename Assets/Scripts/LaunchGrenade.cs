using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGrenade : MonoBehaviour
{
    [SerializeField] GameObject grenade;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] PlayerMovement player;
    [SerializeField] Level01Controller lControl;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            if(lControl.grenades > 0)
            {
                DropBomb();
                Debug.Log("Launched the grenade!");
            }

            else
            {
                Debug.Log("Out of ammo!");
            }
            
        }
    }

    private void DropBomb()
    {
        lControl.grenadeAdjust(false,1);
        Instantiate(grenade, bulletSpawn.position, transform.rotation);
    }
}
