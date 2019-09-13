using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMNG : MonoBehaviour
{
    public static UIMNG I;

    public Slider massBar, scaleBar, cameraScaleBar;

    void Awake() {
        I = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public float GetMass() {
        return massBar.value;
    }

    public float GetScale() {
        return scaleBar.value;
    }

    public void SetCameraScale() {
        Camera.main.orthographicSize = cameraScaleBar.value;
    }
}
