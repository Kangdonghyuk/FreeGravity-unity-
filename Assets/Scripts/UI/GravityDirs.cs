using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDirs : MonoBehaviour
{
    public GameObject gravityDirPrefab;
    Transform[] gravityDirList = new Transform[104];

    Vector3 forceDirection;
    float forceValue;
    float distance;
    float G = 1000;
    bool isCalculate;

    float cameraScale = 1f;

    void Start()
    {
        cameraScale = Camera.main.orthographicSize / 10f;
        for(int y=0; y<8; y++) {
            for(int x = 0; x < 13; x++) {
                gravityDirList[y*13 + x] = Instantiate(gravityDirPrefab,
                    new Vector3((-18 + x * 3) * cameraScale, (-7 + y * 2) * cameraScale, -20f), Quaternion.identity, transform).transform;
                gravityDirList[y*13 + x].localScale = new Vector3(0.5f * cameraScale, 0.4f * cameraScale, 0f);
            }
        }

        isCalculate = false;
    }

    void Update()
    {
        if(!isCalculate)
            return ;

        for(int dirIndex = 0; dirIndex < 104; dirIndex++) {
            forceDirection = Vector3.zero;
            for(int index = 0; index < PlanetMNG.I.planetList.Count; index++) {
                distance = Vector2.Distance(PlanetMNG.I.planetList[index].transform.position, gravityDirList[dirIndex].position);
                forceValue = G * (PlanetMNG.I.planetList[index].mass) / (distance*distance+0.001f);
                forceDirection += (PlanetMNG.I.planetList[index].transform.position - gravityDirList[dirIndex].position) * forceValue;
            }
            gravityDirList[dirIndex].rotation = Quaternion.Euler(0f, 0f, AngleInDeg(gravityDirList[dirIndex].position, forceDirection) + 180f);
        }
    }

    public void ChangeEnable() {
        isCalculate = !isCalculate;

        if(isCalculate) {
            for(int y=0; y<8; y++) {
                for(int x = 0; x < 13; x++) {
                    gravityDirList[y*13 + x].position = new Vector3((-18 + x * 3) * cameraScale, (-7 + y * 2) * cameraScale, -1f);
                }
            }
        }
        else {
            for(int index = 0; index < 104; index++)
                gravityDirList[index].position = Vector3.back * 20;
        }
    }

    public void ChangeCameraScale() {
        float z = -1;
        if(isCalculate == false)
            z = -20f;
        cameraScale = Camera.main.orthographicSize / 10f;
        for(int y=0; y<8; y++) {
            for(int x = 0; x < 13; x++) {
                gravityDirList[y*13 + x].position = new Vector3((-18 + x * 3) * cameraScale, (-7 + y * 2) * cameraScale, z);
                gravityDirList[y*13 + x].localScale = new Vector3(0.5f * cameraScale, 0.4f * cameraScale, 0f);
            }
        }
    }

    public float AngleInRad(Vector3 vec1, Vector3 vec2) {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }

    public float AngleInDeg(Vector3 vec1, Vector3 vec2) {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
    }
}
