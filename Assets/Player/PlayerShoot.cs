using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float projectilespeed;
    public Camera camera;
    public GameObject charaanim;
    public GameObject shield;
    GameObject bouclier;

    // timer bullet // 
    public float timeToDestroy = 10;
    public float timeToDestroyUp;
    // test ienumerator cooldown // 
    private bool canShield = true;
    public float shieldCooldown;
    void Start()
    {
        timeToDestroyUp = 1;
    }
    void Update()
    {
        timeToDestroyUp++;
       // Debug.Log(timeToDestroyUp);
            //fire ball // 
            if (Input.GetButtonDown("Fire1"))
            {
                charaanim.GetComponent<Animator>().Play("fire");
                GameObject projectile = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
                Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                projectileRigidbody.AddForce(camera.transform.forward * projectilespeed);
           


            }
         
        if (timeToDestroyUp>=timeToDestroy)
        {
            Destroy(bullet);
        }
        // Bouclier // 
        if (Input.GetButtonDown("Fire2")&& canShield==true) // active // 
        {
            canShield = false;
            Instantiate(shield, transform.position + (transform.forward * 2), transform.rotation);
            StartCoroutine(Cooldown());
        }
        if (Input.GetButtonUp("Fire2")) // deActive // 
        {
            //Remove shield 
            DestroyImmediate(shield, true);
        }
    }

   


    // Cooldowns 
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(shieldCooldown);
        canShield = true;
    }
    
}
