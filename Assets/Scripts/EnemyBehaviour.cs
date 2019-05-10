using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D enemyRb;
    SpriteRenderer enemySpriteRender;
    Animator enemyAnimator;
    

    float timeBeforeChange;
    public float delay = .5f;
    public float speed = .3f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRender = GetComponent<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetBool("isAlive", true);

    }

    // Update is called once per frame    
    void Update()
    {   
        enemyRb.velocity = Vector2.right * speed;

        // si el if ejecuta una sola linea no hace falta llaves
        if (speed > 0)
        {
            enemySpriteRender.flipX = false;
            enemyAnimator.SetBool("isWalking", true);
        }
        else if(speed < 0)
        {
            enemySpriteRender.flipX = true;
            enemyAnimator.SetBool("isWalking", true);
        }else
        {
            enemyAnimator.SetBool("isWalking", false);
        }


        // Timer simple
        // Time.time , tiempo desde que empezo la aplicacion 
        if (timeBeforeChange < Time.time)
        {
            // Cada que se ejecuta se le añade el tiempo de la proxima ejecución
            speed *= -1;
            // se ejecuta cada cierto tiempo
            timeBeforeChange = Time.time + delay; //el tiempo actual mas el delay
        }


    }
    
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            if (transform.position.y + .3f < collision.transform.position.y)
            {
                enemyAnimator.SetBool("isAlive", false);

            }
        }
    }

    public void DisableEnemy(){

        gameObject.SetActive(false);
        enemySpriteRender.color = new UnityEngine.Color(256f,256f,256f,1f);
        // Si creas y destruyes muchos elementos de forma constante puede ocasionar que el juego
        // se ponga lento devido a tantos borrados en memoria que se hacen         
        // Destroy(gameObject);
    }


}

