using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _dashTime;

    Rigidbody2D rbody;
    float hMove;
    float vMove;
    bool facingRight = true;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        vMove = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyUp(KeyCode.L))
        {
            StartCoroutine(DashTime(_dashTime));
        }
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(hMove * speed, vMove * speed);

        if (hMove > 0 && !facingRight)
        {
            Flip();
        }

        if (hMove < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        gameObject.transform.Rotate(0f,180f,0f);

        facingRight = !facingRight;
    }

    IEnumerator DashTime(float seconds)
    {
        speed = 20f;

        yield return new WaitForSeconds(seconds);

        speed = 10f;
    }
}
