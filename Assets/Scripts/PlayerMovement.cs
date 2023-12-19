using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator myAnim;

    public Rigidbody2D rb;

    public float moveSpeed = 40f;

    public float jump = 0f;

    private Vector2 playerInput;
    private bool shouldJump;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // using "GetAxis" allows for many different control schemes to work here
        // go to Edit -> Project Settings -> Input to see and change them
        playerInput = new Vector2(Input.GetAxis("Horizontal"), 0);
 
        if(canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            shouldJump = true;
        }

        bool movingRight = Input.GetAxisRaw("Horizontal") == 1;
        bool movingLeft = Input.GetAxisRaw("Horizontal") == -1;
        bool jumping = Input.GetKeyDown(KeyCode.Space);

        if (movingRight) {
            myAnim.SetFloat("RightSpeed", 1);
            myAnim.SetFloat("LeftSpeed", 0);
        }

        if (movingLeft) {
            myAnim.SetFloat("LeftSpeed", 1);
            myAnim.SetFloat("RightSpeed", 0);
        }

        if (jumping) {
            myAnim.SetFloat("LeftSpeed", 0);
            myAnim.SetFloat("RightSpeed", 0);
        }

        if (!movingRight && !movingLeft && canJump) {
            myAnim.SetFloat("LeftSpeed", 0);
            myAnim.SetFloat("RightSpeed", 0);
        }
    
    }

    // apply physics movement based on input values
    private void FixedUpdate()
    {
        // move
        if(playerInput != Vector2.zero) {
            transform.Translate(playerInput * Time.fixedDeltaTime * moveSpeed);
            Debug.Log(Time.fixedDeltaTime);
            Debug.Log(playerInput);
        }
     
        // jump
        if(shouldJump) {
            shouldJump = false;
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // allow jumping again
        canJump = true;
    }
 
    private void OnCollisionExit2D(Collision2D col)
    {

    }
}
