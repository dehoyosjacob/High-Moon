using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] Level01Controller lControl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement pMove = other.gameObject.GetComponent<PlayerMovement>();

        if(pMove != null)
        {
            lControl.bulletAdjust(true, 5);
            Destroy(gameObject);
        }
    }
}
