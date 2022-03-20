using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    [SerializeField] float dropTime;
    [SerializeField] GameObject healthPickup;
    [SerializeField] GameObject ammoPickup;

    float rNum;

    public bool startDrop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startDrop == true)
        {
            SelectDrop();
            startDrop = false;
            

        }
    }

    private void SelectDrop()
    {
        rNum = Random.Range(0f, 3f);
        StartCoroutine(RandomDrop(dropTime, rNum));
    }

    IEnumerator RandomDrop(float seconds, float selection)
    {
        yield return new WaitForSeconds(seconds);

        if (selection < 1)
        {
            yield break;
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
