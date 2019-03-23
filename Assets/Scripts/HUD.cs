using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private static int score;
    private static float ballsLeft;

    private static Text scoreText;
    private static Text ballsLeftText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = "Score:  0" ;

        //ballsLeft = ConfigurationUtils.MaxBalls;
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeft").GetComponent<Text>();
        ballsLeftText.text = "Balls Left: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
	/// Updates the score
	/// </summary>
	/// <param name="points">points to add</param>
	public static void AddPoints(int pts)
    {
		score += pts;
		scoreText.text = "Score: " + score;
	}

    /// <summary>
    /// Updates the balls left
    /// </summary>
    public static void ReduceBallsLeft()
    {
        ballsLeft--;
        ballsLeftText.text = "Balls Left: " + ballsLeft;
    }
}
