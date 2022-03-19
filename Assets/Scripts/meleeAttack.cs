using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    [SerializeField] GameObject stake;
    [SerializeField] float _attackTime;
    [SerializeField] AudioSource steakAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            steakAudio.Play();
            StartCoroutine(attackTime(_attackTime));
        }
    }

    IEnumerator attackTime(float seconds)
    {
        stake.SetActive(true);

        yield return new WaitForSeconds(seconds);

        stake.SetActive(false);
    }
}
