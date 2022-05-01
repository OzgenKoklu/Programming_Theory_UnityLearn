using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float ballSpeed = 30;
    private float ballSpeedMultiplier = 3.5f;
    private float zBoundary = -15;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        MoveTowardsCamera();
      
        DestroyOutOfBounds();
    }

    void MoveTowardsCamera()
    {
        
        //speed of the ball changes with respect to distance, a more organic transition would be much better for future improvement
        if (transform.position.z < 40)
        {
            transform.Translate(Vector3.back * Time.deltaTime * ballSpeed);
        }
        else
        {
            transform.Translate(Vector3.back * Time.deltaTime * ballSpeed * ballSpeedMultiplier);
        }
    }
      
    void DestroyOutOfBounds()
    {
        if (transform.position.z < zBoundary)
        {
            Destroy(gameObject);
        }
    }
}
