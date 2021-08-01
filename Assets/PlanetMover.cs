using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] GameObject centrePoint;
    [SerializeField] GameObject altPoint;

    public Vector3 axis = Vector3.up;
    public Vector3 nextPosition;
    public float radius = 2.0f;
    public float orbitSpeed = 80.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = (transform.position - centrePoint.transform.position).normalized * radius + centrePoint.transform.position; // play with this last bit of code to see how it works.
    }

    private void followPath()
    {
        transform.RotateAround(centrePoint.transform.position, axis, orbitSpeed * Time.deltaTime);
        //USE THESE FOR MOON
        //transform.position = (transform.position - centrePoint.transform.position).normalized * radius + centrePoint.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, nextPosition, orbitSpeed * Time.deltaTime);
    }

    private void rotateSphere()
    {
    transform.Rotate(0, rotationSpeed* Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rotateSphere();
        followPath();
    }
}
