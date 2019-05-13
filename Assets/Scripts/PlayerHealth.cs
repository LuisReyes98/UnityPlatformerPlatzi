using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int health = 3;
    public Image[] hearts;
    bool hasCooldown = false;

    AudioSource hurtSound;
    
    // Start is called before the first frame update
    void Start()    
    {
        hurtSound = GetComponents<AudioSource>()[2];
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!(other.transform.position.y + .3f < transform.position.y)) //if the enemy is NOT below the player
            {
                SubstractHealth();

            }
        }else if(other.gameObject.CompareTag("Spike"))
        {
            SubstractHealth();

        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("WorldVoid"))
        {
            SceneChanger.ChangeSceneTo("LostScene");
        }
    }

    void SubstractHealth(){
        if (!hasCooldown)
        {
            if (health > 0)
            {
                health--;
                hurtSound.Play();
                hasCooldown = true;
                StartCoroutine(Cooldown());
            }
        }

        if (health <= 0)
        {
            SceneChanger.ChangeSceneTo("LostScene");
        }

        EmptyHearts();


    }

    void EmptyHearts(){
        for (int i = 0; i < hearts.Length; i++) //for all the hearts
        {
            // if ammount of health -1 < hearts position
            if (health - 1 < i)            
                hearts[i].gameObject.SetActive(false);

            
        }
    }

    IEnumerator Cooldown(){
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;

        StopCoroutine(Cooldown());
    }
}
