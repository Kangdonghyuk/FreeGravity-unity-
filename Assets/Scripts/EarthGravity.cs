using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthGravity : MonoBehaviour
{
    public Transform sun;

    Vector3 gravity;
    float gravityPower;
    float distance;

    void Start()
    {
        gravityPower = 50;
        distance = 0f;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, sun.position);

        if(distance >= gravityPower)
            distance = gravityPower;

        gravity.x = (transform.position.x - sun.position.x) /
            Mathf.Abs((distance / (distance - gravityPower)));
        gravity.y = (transform.position.y - sun.position.y) /
            Mathf.Abs((distance / (distance - gravityPower)));

            //gravity = -gravity / gravityPower;

        transform.position = transform.position + -gravity * Time.deltaTime;
    }
}
