using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    [SerializeField]
    private float TimesUp=5;
    [SerializeField]
    private float startCount=0;
    [SerializeField]
    private float addcount;

    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = startCount;
    }

    // Update is called once per frame
    void Update()
    {
        countdown=countdown+ addcount;
        if (countdown== TimesUp)
        {
            Debug.Log("bulletDestroyed");
            Destroy(gameObject);
        }
    }


}
