﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //define the variables and make them serializable
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;

	// Use this for initialization
	void Start () {
        height = transform.localScale.y;
        speed = 5f;
	}

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;
        if (isRightPaddle)
        {
            //place the Paddle to the right of the screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            //define the input
            input = "PaddleRight";
        }
        else
        {
            // place on the left side of the screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }
        //Update the position of the paddle in the game
        transform.position = pos;
        //Define the name of the object as the input in  this case to know which paddle it is
        transform.name = input;
    }

    // Update is called once per frame
    void Update () {
        //For paddle movement
        //Note: Get axis will be a value between -1 and 1 (neg for down and pos for up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        //Restrict the paddle's movement if it is too high or low (leaving screen)
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
	}
}
