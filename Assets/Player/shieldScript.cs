using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
     public int shieldlife;


    // Start is called before the first frame update
    void Start()
    {
        shieldlife = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shieldlife);  
   if (shieldlife<=0)
        {
            Destroy(gameObject);
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        shieldlife--;
    }
}
