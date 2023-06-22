using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob der Collider mit dem gewünschten Tag getroffen wurde
        if (collision.collider.CompareTag("bullet"))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
