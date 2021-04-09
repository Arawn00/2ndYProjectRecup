using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    private GameObject projectile;
    public Transform spawnpoint;
    public float projectilespeed;
    public Camera camera;
    public GameObject charaanim;
    public GameObject shield;
    GameObject bouclier;

    // test ienumerator cooldown // 
    private bool canShield = true;
    private bool canAttack = true;
    public float shieldCooldown;
    public float attackCooldown;
    public float destroyProjectile;

    void Start()
    {
       
    }
    void Update()
    {
        // détruire balle après x secondes // 
        Invoke("DestroyProjectile", destroyProjectile);
      
            //fire ball // 
            if (Input.GetButtonDown("Fire1")&& canAttack==true)
            {
                charaanim.GetComponent<Animator>().Play("fire");
                projectile = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
                Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                projectileRigidbody.AddForce(camera.transform.forward * projectilespeed);
                canAttack = false;
                StartCoroutine(AttackCooldown());

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
    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    void DestroyProjectile()
    {
        Destroy(projectile);
    }
}
