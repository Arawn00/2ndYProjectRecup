using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiintellingence : MonoBehaviour
{
    
    public GameObject player;
    public Transform spawnpointE;
    public GameObject projectilePrefab;
    public float cooldownShootE;
    public float projectilespeed;
    private bool canShootE = true;

    // rotation ennemy 
    public Transform target;

    private void Update()
    {
        CheckIfAttackMode(55);
        // suivre le joueur du regard //  
        var point = target.position;
        point.y = transform.position.y;
        transform.LookAt(point);
    }
    // State de départ = search player //  


    // Search player = gameobject.find "player" et compare avec une variable de portée de vue // 

    //  check la distance entre l'ennemi & le joueur
    //  
    public float CheckDistanceBetweenaandb(GameObject a, GameObject b)
    {
        float dist = Vector3.Distance(a.transform.position, b.transform.position);
       // Debug.Log(dist);
        return dist;
    }
    
    //  si la distance est inférieur à 55 = passe en attaque  // 

   
    public void CheckIfAttackMode(float ennemyRange)
    {
        if (CheckDistanceBetweenaandb(gameObject, player)<= ennemyRange && canShootE)
        {
            
            //passe en mode attaque 
            Debug.Log("je suis en mode ATK");
            EnemyAttack();
            canShootE = false;
            StartCoroutine(CooldownE());
        }

    }
    // case attack : si à portée de vue  = Attaque() avec un instantiate du projectile ennemi , attaque = faire spawn une boule de feu à partir d'un spawnpoint qui se dirige vers le player 
    public void EnemyAttack()
    {

        GameObject eprojectile =Instantiate(projectilePrefab, spawnpointE.position,spawnpointE.rotation);
        Rigidbody projectileRigidbody = eprojectile.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(gameObject.transform.forward * projectilespeed);
       
       
    }
    // prendre le vecteur de l'ennemi & du  joueur
    // ajouter un cooldown
    private IEnumerator CooldownE()
    {
        yield return new WaitForSeconds(cooldownShootE);
        canShootE = true; // à voir ??? 
    }
    

}
