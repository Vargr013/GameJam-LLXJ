using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    //Declaration 
    public float walkSpeed = 24f;
    public float jumpImpulse = 10f;
    Vector2 moveInput;
    TouchingDirections touchingDirection;

    //Bool to keep track of the players movement status
    [SerializeField]
    private bool _isMoving = false;

    public bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get { return _isFacingRight;}
        
        //Set to flip if needed
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            
            _isFacingRight = value;
        }
    }

    //Property to access it 
    public bool IsMoving 
    {
        get
        {
            return _isMoving;
        }

        set
        { 
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }
    
    //Rigidbody to enable movement 
    public Rigidbody2D rb;
    
    //Animator for animation 
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirection = GetComponent<TouchingDirections>();
    }
    private void FixedUpdate()
    {
        //Set movement
        rb.linearVelocity = new Vector2(moveInput.x * walkSpeed * Time.fixedDeltaTime, rb.linearVelocity.y);
        
        //Jumping code
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Check if moving
        moveInput = context.ReadValue<Vector2>();
        
        //Assign isMoving to control animations
        IsMoving = moveInput != Vector2.zero;
        
        //Change direction accordingly 
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        //Check in which direction the character is facing
        if (moveInput.x > 0 && !IsFacingRight)
        {
            //Facing to the right 
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //Facing to the left 
            IsFacingRight = false;
        }
    }
    
    //Jumping method 
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirection.IsGrounded)
        {
            animator.SetTrigger("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger("Attack");
            
            
        }
    }
}
