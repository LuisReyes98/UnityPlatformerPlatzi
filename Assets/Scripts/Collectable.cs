using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private static int collectableQuantity = 0;
    Text collectableText; //ya que esto se vuelve un prefab no funcionara tener elementos por referencia 
    ParticleSystem collectableParticle;

    AudioSource collectableAudio;

    // Start is called before the first frame update    
    void Start()
    {
        collectableQuantity = 0;//de lo contrario el valor se conservaria entre escenas
        collectableText = GameObject.Find("CollectableQuantityText").GetComponent<Text>();
        
        // collectableText = GameObject.FindObjectOfType(Text);// esto puede dar error si hay mas de un objeto con el mismo tipo de dato

        collectableParticle = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>(); //particula del collecionable
        collectableAudio = GetComponentInParent<AudioSource>(); //sonido del collecionable
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player"))
        {
            collectableParticle.transform.position = transform.position; //make the particle be in the same postion as the collectable
            
            collectableParticle.Play();//play particle 
            
            collectableAudio.Play();//play audio

            gameObject.SetActive(false);
            collectableQuantity++;
            if (collectableQuantity <= 9)
            {
                collectableText.text = "0" + collectableQuantity.ToString();                
            }else{
                collectableText.text = collectableQuantity.ToString();
            }
        }
    }
}
