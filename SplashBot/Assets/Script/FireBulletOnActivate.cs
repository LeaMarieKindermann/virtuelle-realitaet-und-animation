using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = spawnPoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnBullet, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "bot")
        {
            Destroy(collision.gameObject);
            Debug.Log("TERFFER" + collision.gameObject.tag);
        }
        else
        {
            Debug.Log("LLLLLOOOOGGGGG" + collision.gameObject.tag);
        }
    }

}
