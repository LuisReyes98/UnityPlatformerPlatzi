using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D enemyRb;
    SpriteRenderer enemySpriteRender;
    Animator enemyAnimator;
    ParticleSystem onDeathParticle;
    AudioSource deathSound;


    float timeBeforeChange;
    public float delay = .5f;
    public float speed = .3f;    
    public bool isWalker = true;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>(); //get rigid body of self       
        enemySpriteRender = GetComponent<SpriteRenderer>();
        
        enemyAnimator = GetComponent<Animator>();
        
        enemyAnimator.SetBool("isAlive", true); //the enemy is alive
        
        //EnemyParticle
        onDeathParticle = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();

        deathSound = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame    
    void Update()
    {   
        if (isWalker)
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
        }else{

            enemyAnimator.SetBool("isWalking", false);
        }





    }
    
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Death collision
        if (collision.gameObject.CompareTag("Player") ) //if it is player kill enemy
        {
            if (transform.position.y + .3f < collision.transform.position.y)
            {
                enemyAnimator.SetBool("isAlive", false); //no esta vivo
                onDeathParticle.transform.position = transform.position; // particulas moverlas a donde esta el enemigo
                onDeathParticle.Play(); //reproducir paticulas
                deathSound.Play(); //reproducir sonido de muerte

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

