using UnityEngine;

public class HeadHitbox : MonoBehaviour
{
    public int scoreForHit = 5;

    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob die Kollision mit einem Projektil stattfindet
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Vergebe die Punktzahl für das Treffen der Head-Hitbox
            ScoreManager.Instance.AddScore(scoreForHit);

            // Zerstöre das Projektil
            Destroy(collision.gameObject);
        }
    }
}
