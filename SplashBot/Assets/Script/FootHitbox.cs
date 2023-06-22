using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHitbox : MonoBehaviour
{
    public AudioSource fallSound;
    public int scoreForHit = 1;

    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob die Kollision mit einem Projektil stattfindet
        if (collision.gameObject.CompareTag("bullet"))
        {
            fallSound.Play();
            // Vergebe die Punktzahl für das Treffen der Foot-Hitbox
            ScoreManager.Instance.AddScore(scoreForHit);

            // Zerstöre das Projektil
            Destroy(collision.gameObject);
        }
    }
}