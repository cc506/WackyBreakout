using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField]
    Sprite sprite0;
    [SerializeField]
    Sprite sprite1;
    [SerializeField]
    Sprite sprite2;

    // Start is called before the first frame update
    void Start()
    {
        pts = ConfigurationUtils.StandardBlocks;
        switch (Random.Range(0, 3))
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite0;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
