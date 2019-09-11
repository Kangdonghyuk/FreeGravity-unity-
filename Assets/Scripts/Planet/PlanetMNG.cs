using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMNG : MonoBehaviour
{
    public static PlanetMNG I;

    public Planet[] planetList;

    void Awake() {
        I = this;

        planetList = new Planet[transform.childCount];

        for(int index = 0; index < transform.childCount; index++)
            planetList[index] = transform.GetChild(index).GetComponent<Planet>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
