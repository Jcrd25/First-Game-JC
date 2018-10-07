using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    // Use this for initialization
    void Start()
    {
        
        
        direction = Vector2.one.normalized; //direction is (1,1)
        radius = transform.localScale.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }
        //End the round

        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Right Player has won!");
            


        }
        if (transform.position.x > GameManager.bottomLeft.x - radius && direction.x > 0)
        {
            Debug.Log("Left Player has won!");
            
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;

            //reverse the direction if it collided
            if (isRight == true && direction.x > 0)
            {
                // Collided with the right paddle
                direction.x = -direction.x;
            }
            if (isRight == false && direction.x < 0)
            {
                // Collided with the left paddle
                direction.x = -direction.x;
            }

        }
    }

}
