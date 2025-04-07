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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //Add 1 to the score as you picked up the coin
            player.AddScore(1);
            
            //Update score UI 
            uIManager.UpdateScore(player.GetScore());
            
            //Destroy object
            Destroy(gameObject);
            
        }
    }
}
