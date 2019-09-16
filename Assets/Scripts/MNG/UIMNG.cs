using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMNG : MonoBehaviour
{
    public static UIMNG I;

    public Slider massBar, scaleBar, cameraScaleBar;
    public Text startBtnText;
    public Toggle isGravityBtn;

    void Awake() {
        I = this;
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

    public void ClickStartBtn() {
        GameMNG.I.StartGame();
        
        if(startBtnText.text == "Start")
            startBtnText.text = "Stop";
        else if(startBtnText.text == "Stop")
            startBtnText.text = "Start";
    }
}
