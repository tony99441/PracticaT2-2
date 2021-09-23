using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMedianaController : MonoBehaviour
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
        contador = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (contador == 0)
        {
            if (other.gameObject.CompareTag("Enemigo"))
            {
                Debug.Log("Ha topado al enemigo");
               // Destroy(other.gameObject);
               contador = 1;
            }
        }

        if (contador == 1 && other.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Muere");
             Destroy(other.gameObject);
        }

        {
            if (other.gameObject.CompareTag("Enemigo"))
            {
                Debug.Log("Ha topado al enemigo");
                // Destroy(other.gameObject);
                contador = 1;
            }
        }

        
        

        if (other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

   
    
    }
}
