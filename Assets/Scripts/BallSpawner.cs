using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject prefabBall;

    bool retrySpawn = false;
    Timer spawnTimer;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Delay();
        spawnTimer.Run();
        
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
        tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);
    }

    // Update is called once per frame
    void Update()
    {  
        if (retrySpawn || spawnTimer.Finished)
        {
            SpawnBall();

            if(!retrySpawn){
                //resets timer before spawn
                spawnTimer.Duration = Delay();
                spawnTimer.Run();
            }
        }
    }

    /// <summary>
    /// Spawns a ball
    /// </summary>
    public void SpawnBall()
    {
        // make sure we don't spawn into a collision
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(prefabBall);
        }
        else
        {
            retrySpawn = true;
        }
    }

    /// <summary>
    /// Returns a random time from timer between 5 - 10 secs
    /// </summary>
    private float Delay()
	{
		return Random.Range(ConfigurationUtils.MinSeconds, ConfigurationUtils.MaxSeconds);
	}
}
