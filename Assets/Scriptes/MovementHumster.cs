using DitzeGames.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public DitzeGames.MobileJoystick.FixedJoystick Joystick;
    public FixedButton JumpButton;

    public VariableJoystick varJoystick;
    public GameObject damagePoint;
    public Sprite damageSprite;

    public Text lifeScore;
    private int lifes=5;

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
       lifeScore.text = "lifes: " + (lifes).ToString();
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

      /*  float move =Joystick.inputVector.x;

        animator.SetFloat("Speed", Mathf.Abs(move));
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if(move>0 && !isTurnRight)
        {
            TurnRight();
            
        }
        else if(move<0 && isTurnRight)
        {
            
            TurnRight();
           
        }*/

        if (varJoystick.Direction.x != 0)
        {
            float move = varJoystick.Direction.x;

            animator.SetFloat("Speed", Mathf.Abs(move));
            rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

            if (move > 0 && !isTurnRight)
            {
                TurnRight();

            }
            else if (move < 0 && isTurnRight)
            {

                TurnRight();

            }
        }
    }

    void TurnRight()
    {
        isTurnRight = !isTurnRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            animator.SetBool("Loose", true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            StartCoroutine(TakeDamage());
            lifes-=1;
        }
        if (collision.gameObject.tag == "Spike")
        {
            StartCoroutine(TakeDamage());
            lifes -= 100;
        }

    }

      private IEnumerator TakeDamage()
    {
        animator.SetBool("Loose", true);
        
        damagePoint.GetComponent<SpriteRenderer>().sprite = damageSprite;
        yield return new WaitForSeconds(0.5f);
        damagePoint.GetComponent<SpriteRenderer>().sprite = null;
        animator.SetBool("Loose", false);
    }
}
