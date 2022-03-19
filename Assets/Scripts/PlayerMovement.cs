using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _dashTime;
    [SerializeField] GameObject playerFront;
    [SerializeField] GameObject playerBack;
    [SerializeField] GameObject gun;
    [SerializeField] Level01Controller levelController;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource dashAudio;

    Rigidbody2D rbody;
    float hMove;
    float vMove;
    bool facingRight = true;
    bool facingCamera = true;
    

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        playerFront.SetActive(true);
        playerBack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(levelController.justLaunched == false)
        {
            hMove = Input.GetAxisRaw("Horizontal");
            vMove = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Speed", Mathf.Abs(hMove) + Mathf.Abs(vMove));
        }
        

        if(Input.GetKeyUp(KeyCode.L))
        {
            dashAudio.Play();
            StartCoroutine(DashTime(_dashTime));
        }
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(hMove * speed, vMove * speed);

        if (hMove > 0 && !facingRight)
        {
            if (vMove > 0)
            {
                return;
            }
            Flip();
        }

        if (hMove < 0 && facingRight)
        {
            if(vMove > 0)
            {
                return;
            }
            Flip();
        }

        if(vMove > 0)
        {
            playerFront.SetActive(false);
            playerBack.SetActive(true);
        }

        if(vMove < 0)
        {
            playerBack.SetActive(false);
            playerFront.SetActive(true);
        }
    }

    private void Flip()
    {
        gameObject.transform.Rotate(0f, 180f, 0f);
        

        facingRight = !facingRight;
    }

    IEnumerator DashTime(float seconds)
    {
        speed = 20f;

        yield return new WaitForSeconds(seconds);

        speed = 10f;
    }
}
