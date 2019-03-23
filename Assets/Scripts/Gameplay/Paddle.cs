using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rb2D;
	float paddleColliderWidth;
	float paddleColliderHeight;
	private const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		paddleColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
		paddleColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;
	}
	void FixedUpdate()
    {
		 float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                Vector2 position = rb2D.position;
                position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
                position.x = CalculateClampedX(position.x);

                rb2D.MovePosition(position);
            }
	}

    float CalculateClampedX(float x){

		if (x - paddleColliderWidth < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + paddleColliderWidth;
        }
        else if (x + paddleColliderWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - paddleColliderWidth;
        }

        return x;
	}

	/// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && TopCollider(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                paddleColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
      
            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    /// <summary>
    /// Checks for a collision on the top of the paddle
    /// </summary>
    /// <returns><c>true</c>, if collision was on the top of the paddle, <c>false</c> otherwise.</returns>
    /// <param name="coll">collision info</param>
    private bool TopCollider(Collision2D coll){

        ContactPoint2D[] contacts = coll.contacts;

        if(Mathf.Abs(contacts[0].point.y) - Mathf.Abs(gameObject.transform.position.y + paddleColliderHeight) < 0.05f){
            return true;
        }

        return false;
    }

    

	




}
