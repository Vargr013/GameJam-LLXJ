using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;

    private Animator animator; 

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
    
    private int _currentHealth = 100;

    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            
            //Health below 0 
            if (_currentHealth < 0)
            {
                IsAlive = false; 
            }
        }
    }
    
    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvincible = false;

    public float despawnTime = 1.25f;
    private GameObject enemy, player;
    private PlayerController playerController;
    
    [SerializeField]
    private bool isPlayer = false; 
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool("isAlive", value);

            if (gameObject.CompareTag("Player"))
            {
                isPlayer = true;
            }

            //Disable movement 
            //Stop movement for player when dead
            if (isPlayer)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                   
                    if (playerController != null && playerController.rb != null)
                    {
                        playerController.rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    }
                }
            }
            
            if (enemy != null)
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    GameObject.Destroy(enemy, despawnTime);
                }
                
            }
           
            
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        //Stop movement for player when dead
        playerController = player.GetComponent<PlayerController>();
    }
    
    //Declarations for update
    private float timeSinceHit = 0.0f;
    public float invincibleTime = 0.25f;
    
    private void Update()
    {
        if (isInvincible)
        {
            
            if (timeSinceHit > invincibleTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            
            timeSinceHit += Time.deltaTime;
        }
        
        //Hit(10);
    }

    public void Hit(int damage)
    {
        if (IsAlive && !isInvincible)
        {
            CurrentHealth -= damage;
            isInvincible = true;
        }
    }
}
