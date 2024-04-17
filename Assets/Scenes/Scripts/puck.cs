using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class puck : MonoBehaviour
{
    public float Speed = 5f;
    public ScoreScript score_script;
    public Transform centre;

    public int pointsLost = 1;
    public int collisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        score_script = FindObjectOfType<ScoreScript>(); //finding the specifci script
     
    }

   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
          move();
        }
    }

        void move()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = Vector3.right * Speed;
            }

        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            score_script.Enemy_Scorevalue += 1;


            transform.position = centre.position;
            Rigidbody2D rb2 = GetComponent<Rigidbody2D>();
            rb2.velocity = Vector3.zero;
        }

        if (collision.gameObject.CompareTag("AIGoal"))
        {
            score_script.Player_Scorevalue += 1;
            print("Winner");

            transform.position = centre.position;
            Rigidbody2D rb2 = GetComponent<Rigidbody2D>();
            rb2.velocity = Vector3.zero;
        }
        if (collision.gameObject.CompareTag("Exit"))
        {
            transform.position = centre.position;
            Rigidbody2D rb2 = GetComponent<Rigidbody2D>();
            rb2.velocity = Vector3.zero;
        }
        if (collision.gameObject.CompareTag("PlayerPaddle"))
        {
            collisionCount++;

            if (collisionCount == 3) 
            {
                DeductPoints();
                collisionCount = 0;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            ResetCollisionCount();
        }

    }

    void DeductPoints()
    {
        Debug.Log("Point Lost" + pointsLost);
        score_script.PointDeduction(1);
    }

private void ResetCollisionCount() 
    { 
        collisionCount = 0;
    }
}


