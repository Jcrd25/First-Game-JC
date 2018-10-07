using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public Text Scoretext1;
    public Text Scoretext2;
    private void Start()
    {
        Scoretext1.text = PlayerScore1.ToString();
        Scoretext2.text = PlayerScore2.ToString();
    }

    public void UpdateScore()
    {      
        Scoretext1.text = PlayerScore1.ToString();
        Scoretext2.text = PlayerScore2.ToString();
    }

}
