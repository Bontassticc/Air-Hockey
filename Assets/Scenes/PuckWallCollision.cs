using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckWallCollision : MonoBehaviour
{
    public Transform theminObject_X;
    public Transform theminOvject_Y;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if there is a collison with the wall
        if (collision.gameObject.CompareTag("Wall"))

        {
            //reverse the direction of the puck upon collision with the wall
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
        }
       
        Vector3 minValue_X = new Vector3 (1.81f, theminOvject_Y.position.y, 0);
        
    }
}