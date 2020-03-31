using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public Transform playerCamera;

    void OnEnable() {
        if (playerCamera == null) {
            playerCamera = CameraSettings.cs.cam.GetChild(0);
        }
        
    }

    // Update is called once per frame
    void Update() {
        transform.rotation = playerCamera.transform.rotation;
    }
}
