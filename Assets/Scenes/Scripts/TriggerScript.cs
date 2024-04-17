using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public Vector3 newDirection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>(); //This is for the extra feature box, that changes the direction of the puck when colliding.
            if (rb != null)
            {
                rb.velocity = newDirection;
                print("works");
            }
        }
    }
}
