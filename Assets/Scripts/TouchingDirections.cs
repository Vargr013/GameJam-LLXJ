using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    //Declarations 
    public ContactFilter2D castFilter;

    public float groundDistance = 0.05f;

    //Management declataions
    CapsuleCollider2D touchingDirectionsCollider;
    Animator animator;

    RaycastHit2D[] groundhits = new RaycastHit2D[5];

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
