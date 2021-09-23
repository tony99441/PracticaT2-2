using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocityX = 10f;


    

    private int contador = 0; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);

        contador = 5; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Enemigo") ) {
                
                Debug.Log("Ha topado al enemigo");
               Destroy(other.gameObject);
              contador = contador+1;
              Debug.Log(contador);
              if (contador == 5)
              {
                
                  Destroy(other.gameObject);
                  Debug.Log("Debe morir");
              }
            
             } 
        
        
        
        
        

        if (other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

       
    
    }
    
}

