using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{   
    public float mass;
    public float G;
    float distance;
    float forceValue;
    Vector2 forceDirection;

    Rigidbody2D rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rigid.mass = mass;
        
        if(PlanetMNG.I.planetList[0].gameObject == gameObject) {
            rigid.AddForce(Vector2.right * 7000);
        }

        //rigid.AddForce(Vector3.up * 100000f);
    }

    void Update()
    {
    }

    void FixedUpdate() {
        for(int index = 0; index < PlanetMNG.I.planetList.Length; index++) {
            if(PlanetMNG.I.planetList[index].gameObject == gameObject)
                continue;
            distance = Vector2.Distance(PlanetMNG.I.planetList[index].transform.position, transform.position);
            forceValue = G * (PlanetMNG.I.planetList[index].mass * mass) / (distance*distance);
            forceDirection = (PlanetMNG.I.planetList[index].transform.position - transform.position).normalized;

            rigid.AddForce(forceDirection * forceValue);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        
    }
}
