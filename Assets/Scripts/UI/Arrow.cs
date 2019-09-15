using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Vector2 position;
    Vector2 offsetPosition;
    Vector3 validPosition;

    bool isEnable;

    void Start()
    {
        transform.position = new Vector3(0f, 0f, -10f);
        transform.localScale = new Vector3(1f, 0.5f, 1f);
    }

    public float AngleInRad(Vector3 vec1, Vector3 vec2) {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }

    public float AngleInDeg(Vector3 vec1, Vector3 vec2) {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            validPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if(validPosition.y < 0.9 && validPosition.x < 0.9) {
                isEnable = true;
                position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = position;
            }
        }
        if(Input.GetMouseButtonUp(0)) {
            isEnable = false;
            transform.position = new Vector3(0f, 0f, -10f);
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        }

        if(isEnable == true) {
            offsetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.Euler(0f, 0f, AngleInDeg(position, offsetPosition) + 180);
            transform.localScale = new Vector3(Vector3.Distance(position, offsetPosition)/2f, 0.5f, 1f);
        }

    }
}
