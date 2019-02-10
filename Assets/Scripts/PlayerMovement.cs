using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRgBody;
    public float SPEED = 0.5f;
    public float JUMP_SPEED = 100f;
    bool isGrounded = true;
    bool stopJump = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRgBody.velocity = new Vector2(Input.GetAxis("Horizontal") * SPEED,playerRgBody.velocity.y);

        if (isGrounded)//si esta en el piso
        {
            if (Input.GetKeyDown(KeyCode.Space))//preciona la tecla
            {
                playerRgBody.AddForce(Vector2.up * JUMP_SPEED );
                isGrounded = false;
                stopJump = true;

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
                    playerRgBody.velocity = new Vector2(playerRgBody.velocity.x, 0.1f);
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            stopJump = false;
        }
    }
}
