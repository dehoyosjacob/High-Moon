using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _dashTime;
    [SerializeField] GameObject gun;
    [SerializeField] Level01Controller levelController;
    [SerializeField] GameObject hamlet;
    [SerializeField] GameObject littleRed;
    [SerializeField] Animator hamAnim;
    [SerializeField] Animator redAnim;
    [SerializeField] AudioSource dashAudio;

    Rigidbody2D rbody;
    float hMove;
    float vMove;
    bool facingRight = true;
    bool facingCamera = true;
    bool isDashing = false;

    public bool isHam;
    

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        if(isHam)
        {
            hamlet.SetActive(true);
            littleRed.SetActive(false);
        }

        else if(!isHam)
        {
            hamlet.SetActive(false);
            littleRed.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (levelController.justLaunched == false)
        {
            hMove = Input.GetAxisRaw("Horizontal");
            vMove = Input.GetAxisRaw("Vertical");

            hamAnim.SetFloat("Speed", Mathf.Abs(hMove) + Mathf.Abs(vMove));
            redAnim.SetFloat("Speed", Mathf.Abs(hMove) + Mathf.Abs(vMove));
        }




        rbody.velocity = new Vector2(hMove * speed, vMove * speed);
        if (Input.GetKeyUp(KeyCode.L) && !isDashing && (Mathf.Abs(hMove) > 0 || Mathf.Abs(vMove) > 0))
        {
            Debug.Log("begin dash");
            dashAudio.Play();
            StartCoroutine(DashTime(_dashTime));
        }

    }

    private void FixedUpdate()
    {
        

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
        isDashing = true;
        Debug.Log("started coroutine");
        hamAnim.SetBool("isRunning", true);
        redAnim.SetBool("isRunning", true);
        speed = 20f;
        

        yield return new WaitForSeconds(seconds);

        speed = 10f;
        hamAnim.SetBool("isRunning", false);
        redAnim.SetBool("isRunning", false);
        isDashing = false;
    }
}
