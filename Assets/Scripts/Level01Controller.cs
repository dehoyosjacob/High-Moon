using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Controller : MonoBehaviour
{
    bool dracIsAlive = true;
    bool playerIsAlive = true;
    bool hasWon = false;
    bool hasLost = false;

    //temp variables
    int playerHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dracIsAlive == false && playerIsAlive == true)
        {
            hasWon = true;
            Debug.Log("You win!!!");
        }

        else if(playerIsAlive == false)
        {
            hasLost = false;
            Debug.Log("You lose!!!");
        }

        //TEMP
        if(Input.GetKeyUp(KeyCode.T))
        {
            playerHealth -= 5;
            Debug.Log("Player health :: " + playerHealth.ToString());
        }

        if(Input.GetKeyUp(KeyCode.Y))
        {
            dracIsAlive = false;
        }

        if(playerHealth <= 0)
        {
            playerIsAlive = false;
        }
    }
}
