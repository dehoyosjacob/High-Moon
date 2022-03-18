using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text bullets_txt;
    [SerializeField] Text grenades_txt;
    [SerializeField] GameObject hamlet;
    [SerializeField] GameObject littleRed;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject line1;
    [SerializeField] GameObject line2;
    [SerializeField] GameObject line3;
    [SerializeField] GameObject gun;

    bool dracIsAlive = true;
    bool playerIsAlive = true;
    bool hasWon = false;
    bool hasLost = false;
    public int dialogueCount = 1;


    public int bullets;
    public int grenades;
    public bool justLaunched;

    //temp variables
    int playerHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        bullets = 20;
        grenades = 5;
        justLaunched = true;
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(justLaunched == true)
        {
           // dialogueBox.SetActive(true);
            DisplayDialogue(dialogueCount);
            gun.SetActive(false);

            if (Input.GetKeyUp(KeyCode.H))
            {
                dialogueCount++;
                if(dialogueCount <= 4)
                {
                    DisplayDialogue(dialogueCount);
                }
                
            }
        }

        else if(justLaunched == false)
        {
            dialogueBox.SetActive(false);
        }
        

        if (dracIsAlive == false && playerIsAlive == true)
        {
            hasWon = true;
            Debug.Log("You win!!!");
        }

        else if (playerIsAlive == false)
        {
            hasLost = false;
            Debug.Log("You lose!!!");
        }

        //TEMP
        if (Input.GetKeyUp(KeyCode.T))
        {
            playerHealth -= 5;
            Debug.Log("Player health :: " + playerHealth.ToString());
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            dracIsAlive = false;
        }

        if (playerHealth <= 0)
        {
            playerIsAlive = false;
        }
    }

    public void bulletAdjust(bool isIncreasing, int increment)
    {
        if(isIncreasing)
        {
            bullets += increment;
            
        }

        else if(!isIncreasing)
        {
            bullets -= increment;

            if(bullets <= 0)
            {
                bullets = 0;
            }
        }

        bullets_txt.text = "Bullets :: " + bullets.ToString();
    }

    public void grenadeAdjust(bool isIncreasing, int increment)
    {
        if (isIncreasing)
        {
            grenades += increment;

        }

        else if (!isIncreasing)
        {
            grenades -= increment;

            if (grenades <= 0)
            {
                grenades = 0;
            }
        }

        grenades_txt.text = "Grenades :: " + grenades.ToString();
    }

    private void DisplayDialogue(int lineNumber)
    {
        if(dialogueCount == 1)
        {
            line1.SetActive(true);
            line2.SetActive(false);
            line3.SetActive(false);
        }

        else if(dialogueCount == 2)
        {
            line1.SetActive(false);
            line2.SetActive(true);
            line3.SetActive(false);
        }

        else if (dialogueCount == 3)
        {
            line1.SetActive(false);
            line2.SetActive(false);
            line3.SetActive(true);
        }

        else if (dialogueCount == 4)
        {
            dialogueBox.SetActive(false);
            justLaunched = false;
            gun.SetActive(true);
        }
    }
}
