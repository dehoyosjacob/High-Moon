using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject hamlet;
    [SerializeField] GameObject littleRed;

    public bool isHam;
    public bool isRed;

    // Start is called before the first frame update
    void Start()
    {
        if(hamlet != null && littleRed != null)
        {
            hamlet.SetActive(true);
            littleRed.SetActive(false);
            isHam = true;
            isRed = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.D) && isHam && hamlet != null)
        {
            hamlet.SetActive(false);
            littleRed.SetActive(true);
            isHam = false;
            isRed = true;
        }

        if(Input.GetKeyUp(KeyCode.A) && isRed && littleRed != null)
        {
            littleRed.SetActive(false);
            hamlet.SetActive(true);
            isHam = true;
            isRed = false;
        }
    }
}
