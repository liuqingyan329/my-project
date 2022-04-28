using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float runSpeed=5;
    public float jumpSpeed=3;
    public float doublejumpSpeed=5;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet      = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        Jump();
        CheckGrounded();
    }
    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("ground"));
        Debug.Log(isGround);

    }
    void Run()
    {
        //public float Face = Input.GetAxisRaw("Horizontal");
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playVel;
        bool playerHasAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    Vector2 doublejumpVel = new Vector2(0.0f, doublejumpSpeed);
                    myRigidbody.velocity = Vector2.up * doublejumpVel;
                    canDoubleJump = false;
                }
            }
        }
    }
    void Flip()
    {
        bool playerHasAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRigidbody.velocity.x < -0.1f)
           {
                transform.localRotation = Quaternion.Euler(0,180 , 0);

            }
            
        }
    }
}
