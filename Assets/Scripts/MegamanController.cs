using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegamanController : MonoBehaviour
{



   
    public float velocityX;
    public float JumpForce; 
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    private const int Quieto = 0;
    private const int Correr = 1;
    private const int Saltar = 2;
    private const int CorrerDisparar = 3;
    private const int CargaEnergia = 4;

    public GameObject balaDerecha; 
    public GameObject balaIzquierda; 
    
    
    public GameObject balaMedianaDerecha; 
    public GameObject balaMedianaIzquierda; 
    
    

    public GameObject balaGrandeDerecha; 
    public GameObject balaGrandeIzquierda; 

    
    // Aparecer y desaparecer
    private bool EsIntengible = false;
    private float EsIntangibleTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
      
        
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Estado",0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(Correr);
        } 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(Correr);
        } 
        if (Input.GetKeyUp(KeyCode.Space))
        {

            // 2000 para que sea mejor el salto, y ForceMode2d para añadir un poco de fluidez 
            rb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
            changeAnimation(Saltar);
        }

        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            changeAnimation(CorrerDisparar);
        }

        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(CorrerDisparar);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            var bala = sr.flipX ? balaIzquierda : balaDerecha;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = balaDerecha.transform.rotation;
            Instantiate(bala, position, rotation);
        }
    
        if (Input.GetKeyUp(KeyCode.A))
        {
            var balaMediana = sr.flipX ? balaMedianaIzquierda : balaMedianaDerecha;
            var positionM = new Vector2(transform.position.x, transform.position.y);
            var rotationM = balaMedianaDerecha.transform.rotation;
            Instantiate(balaMediana, positionM, rotationM);
        }
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            var balaG = sr.flipX ? balaGrandeIzquierda : balaGrandeDerecha;
            var positionG = new Vector2(transform.position.x, transform.position.y);
            var rotationG = balaGrandeDerecha.transform.rotation;
            Instantiate(balaG, positionG, rotationG);
        }
        
      
     

        
        
        // Intangible para aparecer y desparecer cuando te tocan
        if(EsIntengible && EsIntangibleTime < 3f)
        {
            EsIntangibleTime += Time.deltaTime;
            sr.enabled = !sr.enabled;
            Debug.Log(EsIntangibleTime);
            
            changeAnimation(CargaEnergia);
        }

        else if (EsIntengible && EsIntangibleTime >= 3f)
        {
            EsIntengible = false;
            sr.enabled = true;
            EsIntangibleTime = 0f;
        }

      


    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Carga")&& !EsIntengible)
        {
            EsIntengible = true;
            changeAnimation(CargaEnergia);
            Destroy(collision.gameObject);

        }
    }
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

    
    

}
