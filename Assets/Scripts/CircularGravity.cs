using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularGravity : MonoBehaviour
{
    public float massOfEarth;
    public Transform centerOfEarth;
    public float G;
    public float massOfMoon;
    public Transform centerOfMoon;

    float massOfPlayer;
    float distance;
    float forceValue;
    Vector3 forceDirection;

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        massOfPlayer = rigid.mass;
    }

    void Update()
    {
        distance = Vector3.Distance(centerOfMoon.position, transform.position);
        forceValue = G * (massOfMoon * massOfPlayer) / (distance*distance);
        forceDirection = (centerOfMoon.position - transform.position).normalized;
        rigid.AddForce(forceValue * forceDirection);

        distance = Vector3.Distance(centerOfEarth.position, transform.position);
        forceValue = G * (massOfEarth * massOfPlayer) / (distance*distance);
        forceDirection = (centerOfEarth.position - transform.position).normalized;
        rigid.AddForce(forceValue * forceDirection);
    }
}
