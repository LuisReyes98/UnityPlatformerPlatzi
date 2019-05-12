using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRgBody;
    public float SPEED = 0.5f;
    public float JUMP_SPEED = 100f;

    public Animator playerAnimator;

    public float MAX_JUMP_ANGLE = -0.7f;
    bool isGrounded = true;
    bool stopJump = false;

    AudioSource jumpingSound;
    AudioSource walkingSound;
        
    // Start is called before the first frame update
    void Start()    
    {
        jumpingSound = GetComponents<AudioSource>()[0];
        walkingSound = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento de caminar
        playerRgBody.velocity = new Vector2(Input.GetAxis("Horizontal") * SPEED,playerRgBody.velocity.y);
        
        if (Input.GetAxis("Horizontal") == 0)
        {
            playerAnimator.SetBool("isWalking",false);
        }else if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnimator.SetBool("isWalking",true);

            // Por get component es mas lento
            GetComponent<SpriteRenderer>().flipX = false;
            // pero si es algo sencillo es mas facil que asignar una referencia
            


        }else if (Input.GetAxis("Horizontal") < 0)
        {
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;


        }


        //  Accion de saltar
        if (isGrounded)//si esta en el piso
        {
            
            playerAnimator.SetBool("isJumping", false);//no esta saltando
            // El jugador Salta
            if (Input.GetKeyDown(KeyCode.Space))//preciona la tecla
            {
                jumpingSound.Play(); //sonido de saltar
                playerRgBody.AddForce(Vector2.up * JUMP_SPEED );
                isGrounded = false;
                stopJump = true;
                playerAnimator.SetBool("isJumping",true);

            }            
            // playerAnimator.SetTrigger("Jump");

            if (playerRgBody.velocity.x > 0)
            {
                walkingSound.Play();
            }else{
                walkingSound.Stop();

            }
        }else
        {
            if (stopJump)//para frenar el salto una vez
            {
                if (Input.GetKeyUp(KeyCode.Space))//suelta la tecla
                {
                    //para que el salto se detenga cuando sueltes espacio 
                    // Debug.Log("Solataste saltar");

                    stopJump = false;
                    playerRgBody.velocity = new Vector2(playerRgBody.velocity.x, 0.0f);

                }
                
            }
        }


        

    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectando la dirreción de la colision
        Vector2 player = new Vector2(this.gameObject.transform.position.x,this.gameObject.transform.position.y);

        Vector2 dir = collision.contacts[0].point - player; //vector de la direccion de la colision
        float dirY = dir.normalized.y;

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (dirY < MAX_JUMP_ANGLE)//Si la colision fue desde la parte inferior del jugador aka suelo            
            {
                // Debug.Log(dirY);
                isGrounded = true;
                stopJump = false;
                
            }

        }
    }
    
}

//Como obtener mas de un audio de un mismo componente
// public AudioSource audio1;
//     public AudioSource audio2;

// voidStart(){

//         audio1 = GetComponents<AudioSource>()[0];
//         audio2 = GetComponents<AudioSource>()[1];
//     }

// //caminar
//         if(Input.GetAxis("Horizontal") == 0)
//         {
//             audio2.Play();
//             playerAnim.SetBool("IsWalking", false);
// *
// *
// *
// *
// *
// privatevoidOnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             audio1.Play();
