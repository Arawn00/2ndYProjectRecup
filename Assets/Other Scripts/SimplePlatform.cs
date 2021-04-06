using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatform : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform startPoint, endPoint;

    [SerializeField]
    float changeDirectionDelay;

    private Transform destinationTarget, departTarget;

    private float startTime;

    private float journeyLenght;

    bool isWaiting;


    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;

        startTime = Time.time;
        journeyLenght = Vector3.Distance(departTarget.position, destinationTarget.position);
    }

    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (!isWaiting)
        {
          if (Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
            {
                float distCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distCovered / journeyLenght;
                    transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfJourney);
            }
          else
            {
                isWaiting = true;
                StartCoroutine(changeDelay());
            }
        }
        }
    void changeDestination()
    {
        if(departTarget == endPoint && destinationTarget == startPoint)
        {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else
        {
            departTarget = endPoint;
            destinationTarget = startPoint;
        }
    }
    IEnumerator changeDelay()
    {
        yield return new WaitForSeconds(changeDirectionDelay);
        changeDestination();
        startTime = Time.time;
        journeyLenght = Vector3.Distance(departTarget.position, destinationTarget.position);
        isWaiting = false;
    }

     void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.transform.parent = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }
}
