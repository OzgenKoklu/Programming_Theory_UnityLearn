using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public abstract class BallBehaviour : MonoBehaviour
{
    private float ballSpeed = 30;
    private float ballSpeedMultiplier = 3.5f;
    private float zBoundary = -15;
    protected int scoreToGive = 0;
    protected int timeToGive = 0;

    // ENCAPSULATION
    public virtual int ScoreToGive
    {
        get { return scoreToGive; }
        set => scoreToGive = value;
    }

    public virtual int TimeToGive
    {
        get { return timeToGive; }
        set => timeToGive = value;
    }


    GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
        MoveTowardsCamera();
        }
      
        DestroyOutOfBounds();
    }

    protected void MoveTowardsCamera()
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
      
    protected void DestroyOutOfBounds()
    {
        if (transform.position.z < zBoundary)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
       // GivePoints();
       // Destroy(gameObject);
        
    }


    protected abstract void GivePoints();
   
}
