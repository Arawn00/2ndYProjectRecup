
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float ennemyHp =1;
    public Rigidbody rbEnnemy;
    public float thrust;
    [SerializeField] private Material Ematerial;

  void Awake ()
  {
    rbEnnemy = GetComponent<Rigidbody>();
    Ematerial = GetComponent<Renderer>().material; 
    
  }


  void OnCollisionEnter(Collision other)
    {
        
            if (other.gameObject.tag == "projectile")
            {
                Debug.LogError("Ball shoot. ");

                ennemyHp--;
                EnnemyHit();
            }
    }
  void Update()
  {
      if (ennemyHp<=0)
      {
      Destroy(gameObject);
      Debug.Log("enemy dead");
      }  
  }


    void EnnemyHit(/*GameObject dammageInstigator*/)
   {
     
      ennemyHp --;
     //rbEnnemy.AddForce(0, 0, thrust, Fo rceMode.Impulse); // envoit en Z seulement // 
     //rbEnnemy.AddForce(dammageInstigator.transform.forward * thrust);
      //sound when hit  
      // change material when hit
      InvincibilityFrame();
   }


   void InvincibilityFrame()
      {
        Ematerial.color = Color.white;
        //Invoke("InvincibilityFrameEnd", invicibilityFrame);
      }

    void InvincibilityFrameEnd()
      {
        Ematerial.color = Color.red;
      }

}
 


