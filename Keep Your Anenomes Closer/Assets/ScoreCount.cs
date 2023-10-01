using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount instance; 
    public Text scoreText;

    int score = 0; 

    void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "POINTS: " + score.ToString(); 
    }

    // Update is called once per frame
    public void Addpoint()
    {
        score += 5;
        scoreText.text = "POINTS: " + score.ToString();

    }
}
