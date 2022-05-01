using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private int moveMultiplier = 3;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //ABSTRACTION Example
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft();
        }else if(Input.GetKeyDown(KeyCode.D)){
            moveRight();
        }
    }

     void moveLeft()
    {
        if (transform.position.x > -3 && gameManager.isGameActive)
        {
            transform.position += moveMultiplier * Vector3.left;
        }
    }

     void moveRight()
    {
        if (transform.position.x < 3 && gameManager.isGameActive)
        {
            transform.position += moveMultiplier * Vector3.right;
        }
    }
}
