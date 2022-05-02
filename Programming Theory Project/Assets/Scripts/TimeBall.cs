using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class TimeBall : BallBehaviour
{
    // POLYMORPHISM
    const int timeBonus = 2;
    GameManager gameManager;

    public override int TimeToGive
    {
        get { return timeBonus;}
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
        gameManager.remainingTime += timeBonus;
    }
}
