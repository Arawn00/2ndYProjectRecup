using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Charactermovement : MonoBehaviour
{
    public float Speed;
    public float AccelerationFactor;
    public float DecelerationFactor;
    private Vector3 velocity;



    // Update is called once per frame
    void Update()
    {
        // Get the normalized direction vector 
        float xs = Input.GetAxis("Horizontal");
        float zs = Input.GetAxis("Vertical");
       // Debug.Log("XS:" + xs +"ZS:" + zs);         // vector is inside now // 
 
            
        // Compute  Acceleration Vector 
        Vector3 acceleration = new Vector3(xs,0,zs);
        acceleration.Normalize();
        
        // Player Face Direction 
        Vector3 movement = new Vector3(xs, 0.0f, zs);
        transform.rotation = Quaternion.LookRotation(movement);
        // compute speed 
        velocity += acceleration * AccelerationFactor * Time.deltaTime;
 
        // change position  
        Vector3 speedVector = velocity * Speed * Time.deltaTime;
        transform.position+= speedVector; 
 
        // Deceleration 
        velocity *= DecelerationFactor;
 
             
            
    }
}
