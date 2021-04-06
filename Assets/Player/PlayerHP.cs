using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour
{
    public int currenthp;
    public int maxHealth;
    public bool playerDestroyed;

    // buttons // 
    [SerializeField]
    private GameObject RestartButton;
    [SerializeField]
    private GameObject QuitButton;
    [SerializeField]
    private GameObject BackgroundDeath;
    [SerializeField]
    private GameObject textDead;
    void Start()
    {
        currenthp = maxHealth;
        playerDestroyed = false;
        Debug.Log(currenthp);
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthp <= 0)
        {
            Death();
            //display // 
            RestartButton.SetActive(true);
            QuitButton.SetActive(true);
            BackgroundDeath.SetActive(true);
            textDead.SetActive(true);
        }
        else
        {
            RestartButton.SetActive(false);
            QuitButton.SetActive(false);
            BackgroundDeath.SetActive(false);
            textDead.SetActive(false);
        }
        /*if (Input.GetKeyDown("f"))
        {
            currenthp--;
            Debug.Log(currenthp);
        }*/
    }

// subir des dégats // 

void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("DamageE")) // take dammage by Eprojectile
        {
            takeLowDammage(); // set dommage içi 
            Debug.LogError("DAMAGE TAKEN");
            Debug.Log("Hit");
            Debug.Log(currenthp);
        }
    }
    void Death()
    {
    Destroy(gameObject);
    playerDestroyed = true;
    // load death scene or display button for respawn 
    
    }


    public void takeLowDammage()
    {
        int dammage = 1;
        currenthp = currenthp - dammage;
    }
    public void instantKill()
    {
        int dammage = 3;
        currenthp = currenthp - dammage;
    }
}
