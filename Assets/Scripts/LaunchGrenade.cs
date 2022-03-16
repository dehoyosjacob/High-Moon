using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGrenade : MonoBehaviour
{
    [SerializeField] GameObject grenade;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            DropBomb();
            Debug.Log("Launched the grenade!");
        }
    }

    private void DropBomb()
    {
        Instantiate(grenade, bulletSpawn.position, transform.rotation);
    }
}
