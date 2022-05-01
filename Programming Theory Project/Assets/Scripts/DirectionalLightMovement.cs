using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightMovement : MonoBehaviour
{
    private float rotationMultiplier = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateLight();
    }

    private void rotateLight()
    {
        //I'm planning on implementing more exotic movement in the future
        transform.Rotate(Vector3.up * rotationMultiplier * Time.deltaTime);
    }
}
