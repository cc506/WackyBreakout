using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;

    Timer delayTimer;
    Timer deathTimer;

    BallSpawner ballSpawner;
    void Start()
    {
        // start move timer
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 1;
        delayTimer.Run();

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeTime;
        deathTimer.Run();
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        ballSpawner = Camera.main.GetComponent<BallSpawner>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(delayTimer.Finished){
            delayTimer.Stop();
            rigidbody2D.AddForce(Vector2.down * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);
        }
        if(deathTimer.Finished){
            // spawn new ball and destroy self
            Destroy(gameObject);
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
        }
    }

    void OnBecameInvisible()
    {
        if (gameObject.transform.position.y < ScreenUtils.ScreenBottom)
			{
				ballSpawner.SpawnBall();
			}
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
	{
		rigidbody2D.velocity = rigidbody2D.velocity.magnitude * direction;
	}
}
