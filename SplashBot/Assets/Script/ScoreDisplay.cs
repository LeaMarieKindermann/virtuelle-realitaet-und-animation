using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour

    
{
    public TextMeshPro scoreText;

    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreManager.score;
    }
}
