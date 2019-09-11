using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMNG : MonoBehaviour
{
    public Transform spaceship;

    Camera viewCamera;
    float viewSizeX;
    float viewSizeY;

    void Awake() {
        viewCamera = GetComponent<Camera>();
    }

    void Start()
    {
        viewSizeX = 11;
        viewSizeY = 11;
    }

    void Update()
    {
        viewSizeX = 11 + (Mathf.Abs(spaceship.position.x) - 10);
        viewSizeY = 11 + (Mathf.Abs(spaceship.position.y) - 7f);

        if(viewSizeX < 11) viewSizeX = 11;
        if(viewSizeY < 11) viewSizeY = 11;

        viewCamera.orthographicSize = viewSizeX > viewSizeY ? viewSizeX : viewSizeY;
    }
}
