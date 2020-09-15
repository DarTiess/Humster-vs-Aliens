using DitzeGames.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AppleShooter))]
public class MovementHumster : MonoBehaviour
{
    private AppleShooter appleShooter { get; set; }
    public float maxSpeed = 10.0f;
    private bool isTurnRight = true;

    public Animator animator;
    private Rigidbody2D rigidbody2D;

    private bool isGrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask layerMask;

    public FixedJoystick Joystick;
    public FixedButton JumpButton;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isGrounded && JumpButton.Pressed)
        {
            animator.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, 300));
        }
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, layerMask);
        animator.SetBool("Ground", isGrounded);
        animator.SetFloat("vSpeed", rigidbody2D.velocity.y);

        if (!isGrounded)
            return;

        float move = Joystick.inputVector.x;

        animator.SetFloat("Speed", Mathf.Abs(move));
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if(move>0 && !isTurnRight)
        {
            TurnRight();
            
        }
        else if(move<0 && isTurnRight)
        {
            
            TurnRight();
           
        }
    }

    void TurnRight()
    {
        isTurnRight = !isTurnRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
