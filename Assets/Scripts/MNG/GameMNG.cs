using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMNG : MonoBehaviour
{
    public static GameMNG I;
    Vector3 mousePosition;
    Vector3 mouseDownPosition;
    Vector3 mouseUpPosition;
    bool isCreate;

    void Awake() {
        I = this;
    }

    void Start()
    {
        mousePosition = Input.mousePosition;
        mouseDownPosition = Input.mousePosition;
        mouseUpPosition = Input.mousePosition;

        Time.timeScale = 0f;
        isCreate = false;
    }

    void Update()
    {

        //if(Input.GetMouseButtonDown(0))
        //    Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        
        mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mousePosition.z = 0;

        if(Input.GetMouseButtonDown(0) && mousePosition.y < 0.9 && mousePosition.x < 0.9) {
            mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDownPosition.z = 0f;
            isCreate = true;
        }

        if(Input.GetMouseButtonUp(0) && isCreate == true) {
            mouseUpPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseUpPosition.z = 0f;
            CreatePlanet();
        }
    }

    void CreatePlanet() {
        PlanetMNG.I.CreatePlanet(
            mouseDownPosition, UIMNG.I.GetMass(), UIMNG.I.GetScale(),
            (mouseUpPosition - mouseDownPosition), UIMNG.I.isGravityBtn.isOn);
        isCreate = false;
    }

    public void StartGame() {
        Time.timeScale = Mathf.Abs(Time.timeScale - 1f);
    }
}
