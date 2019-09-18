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
    public Vector2 velocity;

    public Transform gravityScale1, gravityScale2;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();

        //gravityScale1 = transform.Find("GravityScale1");
        //gravityScale2 = transform.Find("GravityScale2");
    }

    void Start()
    {
        rigid.gravityScale = 0;
        rigid.mass = mass;

        //rigid.AddForce(forceStart * 1000);
    }

    public void SetAttribute(float mass, float scale, bool isGravity) {
        this.mass = mass;
        transform.localScale = new Vector3(scale, scale, 1);
        this.isGravity = isGravity;
        if(!isGravity)
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;

        gravityScale1.localScale = new Vector3(0.5f + mass / 1000, 0.5f + mass / 1000, 1);
        gravityScale2.localScale = new Vector3(1.0f + mass / 500, 1.0f + mass / 500, 1);
    }

    public void AddForce(Vector2 force) {
        rigid.AddForce(force * 100 * mass);
    }

    void Update()
    {
        velocity = rigid.velocity;
    }

    void FixedUpdate() {
        if(isGravity)
            Gravity();
    }

    void Gravity() {
        float distance;

        for(int index = 0; index < PlanetMNG.I.planetList.Count; index++) {
            if(PlanetMNG.I.planetList[index].gameObject == gameObject)
                continue;
            distance = Vector2.Distance(PlanetMNG.I.planetList[index].transform.position, transform.position);
            forceValue = G * (PlanetMNG.I.planetList[index].mass * mass) / (distance*distance);
            forceDirection = (PlanetMNG.I.planetList[index].transform.position - transform.position).normalized;

            rigid.AddForce(forceDirection * forceValue);
        }
    }
}
