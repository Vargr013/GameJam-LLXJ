using TMPro;
using UnityEngine;



public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI scoreCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int newScore)
    {
        scoreCounter.text = "Score: " + newScore;
    }
}
