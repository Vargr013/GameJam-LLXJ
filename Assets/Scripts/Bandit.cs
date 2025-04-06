using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Animator))]
public class Bandit : MonoBehaviour
{
    public float walkSpeed = 3f;
    public DetectionZone attackZone;
    public DetectionZone cliffDetectionZone;

    private Rigidbody2D rb;
    TouchingDirections direction;
    Animator animator;
    
    
    public enum WalkableDirection
    {
        Right, Left
    }
    
    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {

            if (_walkDirection != value)
            {
                //Direction flipped 
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                    
                }
                else if (value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }
                
            }
            _walkDirection = value;
        }
    }
    public bool _HasTarget = false;
    
    public bool HasTarget
    {
        get { return _HasTarget;}
        private set
        {
            animator.SetBool("hasTarget", value);
            _HasTarget = value;
        } 
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
    }

    private void FixedUpdate()
    {
        if (direction.IsGrounded && direction.IsOnWall || cliffDetectionZone.detectedColliders.Count == 0)
        {
            FlipDirection();
        }
        rb.linearVelocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.linearVelocity.y);
        
    }

    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
        else if (WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


}
