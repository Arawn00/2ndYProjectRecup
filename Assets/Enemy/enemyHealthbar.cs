using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* some info how to introduce this script into the game
1) put the canvas with health bar as a child of an enemy game object 
2) attach this script to the enemy game object
3) in the inspector under this script put the slider (find it in canvas world slider), set the damage,max health, current health etc
4) Note: Both GameObjects must contain a Collider component. One must have Collider.isTrigger enabled, and contain a Rigidbody.
If both GameObjects have Collider.isTrigger enabled, no collision happens. The same applies when both GameObjects do not have a Rigidbody component.

 */


public class enemyHealthbar : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth;
    public float currentHealthEnemy;
    public float damage = 10;
    public bool enemyDestroyed;
    public GameObject enemy;
    public GameObject fxIsHit;

    private Animator anim;

    private void Awake()
    {

        currentHealthEnemy = maxHealth;
        healthSlider.maxValue = maxHealth;
    }



    void Start()
    {
        enemyDestroyed = false;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //healthbar facing camera
        healthSlider.transform.rotation = Camera.main.transform.rotation;

        healthSlider.value = currentHealthEnemy;


        //if health 0 - destroy object (calls a function below)
        if (currentHealthEnemy <= 0)
        {
        //anim.Play("Death");
        enemy.GetComponent<Animator>().Play("Death");   
        Invoke("DestroyGameObject", 6f);
        Debug.LogError("DESTROY");
        }


        // this is just to test if the slider works
        if (Input.GetKey("m"))
        {
        currentHealthEnemy = currentHealthEnemy - damage;
        }


    }

    //function that destroys object
    void DestroyGameObject()
    {
    Destroy(gameObject);
    enemyDestroyed = true;
    }

    //function that makes an enemy take damage if he collides with object with tag damage, please put tag player on the object that will collide with an enemy (fireball)
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");

        if (other.gameObject.CompareTag("Damage") )
        {
            currentHealthEnemy = currentHealthEnemy - damage;
            //FX//
            Instantiate(fxIsHit, enemy.transform.position, Quaternion.identity);
            //stop fx // 

            Debug.LogError("DAMAGE TAKEN");
            //destroy gameobject bullet when hit 
            
        }
    }

}
