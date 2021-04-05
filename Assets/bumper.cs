using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour
{
    
public int bumperForce = 800;
public GameObject player;
   
    
  // on collision enter => check collisions  // 

void Start()
{
  player=GameObject.FindGameObjectWithTag ("Player"); // prends le game object en utilisant le tag player
  
 
}
    public void OnCollisionEnter(Collision collider) // Add thrust when collisions is true 
    {
      // si le bumper entre en collisions avec le player // 
      if (collider.gameObject == player)
      {
        // ajouter de la force au rigidbody du player //
        player.GetComponent<Rigidbody>().AddForce(0, bumperForce, 0); 
      }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
