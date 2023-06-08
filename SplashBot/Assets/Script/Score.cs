using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private long score;

    public SpawnBots spawnBotsScript;

    void Start()
    {
        spawnBotsScript = GetComponent<SpawnBots>();

         scoreText = GetComponent<Text>();
       
        UpdateScoreText();
    }

   // Update is called once per frame
     void Update()
     {
        UpdateScoreText();
     }

     void UpdateScoreText()
    {
         score = spawnBotsScript.score;
        scoreText.text = "Score: " + score.ToString();
    }

   
}
