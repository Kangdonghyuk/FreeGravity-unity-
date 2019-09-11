using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{   
    public float mass;
    public float G;
    float distance;
    float forceValue;
    Vector3 forceDirection;

    Rigidbody2D rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        mass = rigid.mass;

        rigid.AddForce(Vector3.up * 100000f);
    }

    void Update()
    {
    }

    void FixedUpdate() {
        for(int index = 0; index < PlanetMNG.I.planetList.Length; index++) {
            distance = Vector3.Distance(PlanetMNG.I.planetList[index].transform.position, transform.position);
            forceValue = G * (PlanetMNG.I.planetList[index].mass * mass) / (distance*distance);
            forceDirection = (PlanetMNG.I.planetList[index].transform.position - transform.position).normalized;
            rigid.AddForce(forceValue * forceDirection);
        }

        
    }
}
