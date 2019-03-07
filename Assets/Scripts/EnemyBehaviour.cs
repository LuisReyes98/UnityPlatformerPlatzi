using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D enemyRb;
    float timeBeforeChange;
    public float delay = .5f;
    public float speed = .3f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        enemyRb.velocity = Vector2.right * speed;

        // Timer simple
        // Time.time , tiempo desde que empezo la aplicacion 
        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            // se ejecuta cada cierto tiempo
            timeBeforeChange = Time.time + delay; //el tiempo actual mas el delay
        }


    }
    
}
