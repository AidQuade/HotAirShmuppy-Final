using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour {
    public Transform enemy;

    public float xSpacing, ySpacing;
    public float xOrigin, yOrigin;
    public int numRows, numColumns;

    public float speed = 2f;
    public float amplitude = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy);
        
    }
        
    
void Update()
    {
        

    }

}
