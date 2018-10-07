using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //definet the properties of both paddle and ball and make them public
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    public 
    // Use this for initialization
    void Start()
    {
        //Convert the screen's pixel coordinates into the actual game coordinates
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Make the ball and the two paddles
        Instantiate(ball);
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init(true); // right paddle
        paddle2.Init(false);// left paddlle

    }
    public void EndRound()
    {
        Debug.Log("End Round");
    }
}