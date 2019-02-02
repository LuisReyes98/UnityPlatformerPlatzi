using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRgBody;
    public float SPEED = 0.5f;
    public float JUMP_SPEED = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRgBody.velocity = new Vector2(Input.GetAxis("Horizontal") * SPEED,playerRgBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRgBody.AddForce(Vector2.up * JUMP_SPEED );
            

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //para que el salto se detenga cuando sueltes espacio 
            playerRgBody.velocity = new Vector2(playerRgBody.velocity.x, 0.1f);
        }
    }
}
