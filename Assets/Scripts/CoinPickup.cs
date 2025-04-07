using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public PlayerController player;
    public UIManager uIManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (uIManager == null)
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame 
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coin detected collision");
            
            //Destroy object
            Destroy(gameObject);
            
            //Add 1 to the score as you pick up the coin
            player.AddScore(1);
            
            //Update score UI 
            uIManager.UpdateScore(player.GetScore());

            
            
            
        }
    }
}
