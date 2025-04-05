using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    //Declarations 
    public ContactFilter2D castFilter;

    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;

    //Management declataions
    CapsuleCollider2D touchingDirectionsCollider;
    Animator animator;

    RaycastHit2D[] groundhits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    //Variable to keep track if player is on the ground 
    [SerializeField]
    private bool _isGrounded = false;

    public bool IsGrounded
    {
        //Normal Getter
        get { return _isGrounded; }
        //Custom setter
        set
        {
            _isGrounded = value;
            animator.SetBool("isGrounded", _isGrounded);
        }
    }
    
    //Variable to keep track if player is by wall 
    [SerializeField]
    private bool _isOnWall = false;

    public bool IsOnWall
    {
        //Normal Getter
        get { return _isOnWall; }
        //Custom setter
        set
        {
            _isOnWall = value;
            animator.SetBool("isOnWall", _isOnWall);
        }
    }
    
    //Variable to keep track if player is on ceiling
    [SerializeField]
    private bool _isOnCeiling = false;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool IsOnCeiling
    {
        //Normal Getter
        get { return _isOnCeiling; }
        //Custom setter
        set
        {
            _isOnCeiling = value;
            animator.SetBool("isOnCeiling", _isOnCeiling);
        }
    }

    //Awake method 
    private void Awake()
    {
        touchingDirectionsCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Check if player is on the ground
        IsGrounded = touchingDirectionsCollider.Cast(Vector2.down, castFilter, groundhits, groundDistance) > 0;
        IsOnWall = touchingDirectionsCollider.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingDirectionsCollider.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
