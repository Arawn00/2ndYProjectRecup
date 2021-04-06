using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBat : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public float cooldownShootE;

    private bool canAttack = true;

    void Update()
    {

    }

    // check distance // 
    public float CheckDistanceBetweenaandb(GameObject a, GameObject b)
        {
            float dist = Vector3.Distance(a.transform.position, b.transform.position);
            // Debug.Log(dist);
            return dist;
        }

        public void CheckIfAttackMode(float ennemyRange)
        {
            if (CheckDistanceBetweenaandb(gameObject, player) <= ennemyRange && canAttack)
            {

                //passe en mode attaque 
                Debug.Log("je suis en mode ATK");
                EnemyAttack();
                canAttack = false;
                StartCoroutine(CooldownE());
            }
        }

        public void EnemyAttack()
        {
            // melee attack 
            Debug.Log("BatATTACK");
        }

        private IEnumerator CooldownE()
        {
            yield return new WaitForSeconds(cooldownShootE);
            canAttack = true; // à voir ??? 
        }
    // if < x = chase player 
    // if > x = return to idle 

    // if Bat collide Player apply dammage // 



   
}