using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpaddleController : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public float moveSpeed; //Speed at which the AI puck will move
    public int ForcePower;
    [SerializeField] float PositiveBoundaryX;
    [SerializeField] float NegativeBoundaryY; //this is to figure out the cordinations to create the boundary for the AI
    [SerializeField] float PositiveBoundaryY;
    [SerializeField] float NegativeBoundaryX;

    public Transform puck; //Reference to the pucks transform 
    public puck puck_Script; //calling puck script

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        puck_Script = FindObjectOfType<puck>();//this was so that it would be easy for this script to find the Puck script, since it did not know
    }

    private void FixedUpdate()
    {
        if (gameObject.CompareTag("AIPaddle")) 
        {
            if (transform.position.x < PositiveBoundaryX) 
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                transform.position = new Vector2(PositiveBoundaryX, transform.position.y);
            }
            if (transform.position.x > NegativeBoundaryX)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                transform.position = new Vector2(NegativeBoundaryX, transform.position.y);
            }
        }
        if (gameObject.CompareTag("AIPaddle")) //this was to keep the AI paddle from roaming out of it's boundaries
            
            if (transform.position.y > PositiveBoundaryY)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                transform.position = new Vector2(transform.position.x, PositiveBoundaryY); //the use of transform was genrally to make it easier even though it is not complete physics
            }
            else if (transform.position.y < NegativeBoundaryY)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                transform.position = new Vector2(transform.position.x, NegativeBoundaryY);
            }
        
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            print("Working yes");
            Vector2 forcedirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(forcedirection * ForcePower, ForceMode2D.Impulse);

            //this was to add some power for when the paddles hit the puck, that htere is some oomf behind it
        }
    }

    void Update()
    {
        if (puck != null)
        {
            Vector2 stopman = transform.position;

          //  stopman.x = maxValue_X;
           // stopman.x = maxValue_Y;

            rb.MovePosition(Vector2.MoveTowards(rb.position, puck_Script.transform.position, moveSpeed * Time.deltaTime));

        }
    }
}
