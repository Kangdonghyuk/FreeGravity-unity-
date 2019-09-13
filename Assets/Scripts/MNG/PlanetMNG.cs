using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMNG : MonoBehaviour
{
    public static PlanetMNG I;

    public GameObject planetPrefab;

    public List<Planet> planetList;
    int planetCount;

    void Awake() {
        I = this;
    }

    void Start()
    {
        planetList = new List<Planet>();
        planetCount = 0;
    }


    void Update()
    {
        
    }

    public void CreatePlanet(Vector3 position, float mass, float scale, Vector3 forceDirection) {
        planetList.Add(Instantiate(planetPrefab, position, Quaternion.identity).GetComponent<Planet>());
        planetList[planetCount].transform.SetParent(transform);
        planetList[planetCount].SetAttribute(mass, scale, true);
        planetList[planetCount].AddForce(forceDirection);
        planetCount+=1;
    }
}
