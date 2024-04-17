using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPaddle : MonoBehaviour, IEventSystemHandler, IDragHandler 
{
    [SerializeField]
    float steerSpeed = 0.1f;
    [SerializeField]
    float moveSpeed = 0.01f;
    private Vector3 offset;

   
    public float minValue_X = 1f;
    public float minValue_Y = 1f;
    public float maxValue_X = 1f;
    public float maxValue_Y = 1f;
    public int ForcePower;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = transform.position.z; 
        transform.position = newPosition;
    }

    void Update()
    {
        Vector3 stopman = transform.position;

        stopman.y = Mathf.Clamp(stopman.y, maxValue_Y, minValue_Y);
        stopman.x = Mathf.Clamp(stopman.x, maxValue_X, minValue_X);

        transform.position = stopman;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            print("Working yes");
            Vector2 forcedirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(forcedirection * ForcePower, ForceMode2D.Impulse);
        }
    }

    //if puck, collides with playerpaddle and then AIpaddle neautral
    //if puck collides with player paddle and player paddle -1 score.
}
