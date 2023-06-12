using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private long score;

    public SpawnBots spawnBotsScript;

    void Start()
    {
        spawnBotsScript = FindObjectOfType<SpawnBots>();

         scoreText = transform.Find("Score").GetComponent<Text>();

         score = spawnBotsScript.score;
       
       // UpdateScoreText();

       // Debug.Log("score: "+ score);
    }

   // Update is called once per frame
     void Update()
     {
       // UpdateScoreText();
     }

     void UpdateScoreText()
    {
         score = spawnBotsScript.score;
        scoreText.text = "Score: " + score.ToString();
    }

   
}
