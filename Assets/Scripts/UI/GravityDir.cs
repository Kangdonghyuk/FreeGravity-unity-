using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDir : MonoBehaviour
{
    Vector3 forceDirection;
    float forceValue;
    float G = 1000;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;

        float distance;

        forceDirection = Vector3.zero;
        for(int index = 0; index < PlanetMNG.I.planetList.Count; index++) {
            distance = Vector2.Distance(PlanetMNG.I.planetList[index].transform.position, transform.position);
            forceValue = G * (PlanetMNG.I.planetList[index].mass * PlanetMNG.I.planetList[index].mass) / (distance*distance+0.001f);
            forceDirection += (PlanetMNG.I.planetList[index].transform.position - transform.position) * forceValue;
        }
        
        transform.rotation = Quaternion.Euler(0f, 0f, AngleInDeg(transform.position, forceDirection) + 180f);
    }

    public float AngleInRad(Vector3 vec1, Vector3 vec2) {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }

    public float AngleInDeg(Vector3 vec1, Vector3 vec2) {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
    }
}
