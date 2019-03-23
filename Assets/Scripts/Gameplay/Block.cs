using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    protected int pts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///</summary>
    
    public void OnCollisionEnter2D(Collision2D coll)
	{
        if(coll.gameObject.tag == "Ball")
        {
            HUD.AddPoints(pts);
            Destroy(gameObject);
        }	
	}
}
