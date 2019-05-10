using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    [SerializeField]
    private static int collectableQuantity = 0;
    public Text collectableText;
    // Start is called before the first frame update    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player"))
        {
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
