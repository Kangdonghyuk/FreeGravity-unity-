using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public bool isGravity;
    public float mass = 1;
    public float G = 1; // gravity constant number, generally set 1

    Rigidbody2D rigid;
    float forceValue;
    Vector2 forceDirection;
    public Vector2 forceStart; 

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rigid.gravityScale = 0;
        rigid.mass = mass;

        rigid.AddForce(forceStart * 1000);
    }

    void Update()
    {
        
    }

    void FixedUpdate() {
        if(isGravity)
            Gravity();
    }

    void Gravity() {
        float distance;

        for(int index = 0; index < PlanetMNG.I.planetList.Length; index++) {
            if(PlanetMNG.I.planetList[index].gameObject == gameObject)
                continue;
            distance = Vector2.Distance(PlanetMNG.I.planetList[index].transform.position, transform.position);
            forceValue = G * (PlanetMNG.I.planetList[index].mass * mass) / (distance*distance);
            forceDirection = (PlanetMNG.I.planetList[index].transform.position - transform.position).normalized;

            rigid.AddForce(forceDirection * forceValue);
        }
    }
}
