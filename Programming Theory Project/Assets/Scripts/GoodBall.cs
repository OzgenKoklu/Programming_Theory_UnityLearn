using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class GoodBall : BallBehaviour
{
    // POLYMORPHISM
    const int GoodPoints = 5;
    GameManager gameManager;
    public override int ScoreToGive
    {
        get { return GoodPoints; }
    }
    private new void Start()
    {
        base.Start();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private new void OnTriggerEnter(Collider other)
    {
        GivePoints();
        Destroy(gameObject);
    }
    // POLYMORPHISM 
    protected override void GivePoints()
    {
        gameManager.playerScore += GoodPoints;
    }
}
