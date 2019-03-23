using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
	public GameObject PaddlePrefab;
    [SerializeField]
    public GameObject StandardBlockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PaddlePrefab);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
