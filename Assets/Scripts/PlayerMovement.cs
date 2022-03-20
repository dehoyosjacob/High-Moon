using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _dashTime;
    [SerializeField] GameObject gun;
    [SerializeField] Level01Controller levelController;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource dashAudio;

    Rigidbody2D rbody;
    float hMove;
    float vMove;
    bool facingRight = true;
    bool facingCamera = true;
    bool isDashing = false;
    

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        if (levelController.justLaunched == false)
        {
            hMove = Input.GetAxisRaw("Horizontal");
            vMove = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Speed", Mathf.Abs(hMove) + Mathf.Abs(vMove));
        }


        if (Input.GetKeyUp(KeyCode.L) && !isDashing && (Mathf.Abs(hMove) > 0 || Mathf.Abs(vMove) > 0))
        {
            dashAudio.Play();
            StartCoroutine(DashTime(_dashTime));
        }

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
    }

    private void Flip()
    {
        gameObject.transform.Rotate(0f, 180f, 0f);
        

        facingRight = !facingRight;
    }

    IEnumerator DashTime(float seconds)
    {
        
        animator.SetBool("isRunning", true);
        speed = 20f;
        isDashing = true;

        yield return new WaitForSeconds(seconds);

        speed = 10f;
        animator.SetBool("isRunning", false);
        isDashing = false;
    }
}
