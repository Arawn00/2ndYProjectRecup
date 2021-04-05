using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float projectilespeed;
    public Camera camera;
    public GameObject charaanim;
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Fire1"))
        {
        charaanim.GetComponent<Animator>().Play("fire");
        GameObject projectile = Instantiate(bullet,spawnpoint.position,spawnpoint.rotation);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(camera.transform.forward*projectilespeed);
        }
    }
}
