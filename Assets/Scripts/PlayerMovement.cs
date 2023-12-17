using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator myAnim;

    public Rigidbody2D rb;

    public float moveSpeed = 40f;

    float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool movingRight = Input.GetAxisRaw("Horizontal") == 1;
        bool movingLeft = Input.GetAxisRaw("Horizontal") == -1;

        if (movingRight) {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),0) * moveSpeed;
            myAnim.SetFloat("RightSpeed", 1);
            myAnim.SetFloat("LeftSpeed", 0);
        }

        if (movingLeft) {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),0) * moveSpeed;
            myAnim.SetFloat("LeftSpeed", 1);
            myAnim.SetFloat("RightSpeed", 0);
        }

        if (!movingRight && !movingLeft) {
            myAnim.SetFloat("LeftSpeed", 0);
            myAnim.SetFloat("RightSpeed", 0);
        }
    
    }
}
