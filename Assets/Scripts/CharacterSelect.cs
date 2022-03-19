using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject hamlet;
    [SerializeField] GameObject littleRed;

    public bool isHam;

    // Start is called before the first frame update
    void Start()
    {
        if(hamlet != null && littleRed != null)
        {
            hamlet.SetActive(true);
            littleRed.SetActive(false);
            isHam = true;
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
        }

        if(Input.GetKeyUp(KeyCode.A) && !isHam && littleRed != null)
        {
            littleRed.SetActive(false);
            hamlet.SetActive(true);
            isHam = true;
        }
    }
}
