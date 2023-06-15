using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("bot"))
    {
        Debug.Log("Kollision mit Bot");
        Destroy(collision.gameObject);
        Destroy(gameObject); // Zerstöre das Bullet-Objekt
    }
    else
    {
        Debug.Log("Kollision mit anderem Objekt " + collision.gameObject.tag);
    }
}
}
