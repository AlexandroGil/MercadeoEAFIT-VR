using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour {

    public static CameraSettings cs;

    public Transform cam;
    [Range(0,2)]
    public float cameraHeight = 1.6f;
    public float colliderSize = 0.55f;

    [Header("Movement")]
    public Vector3 targetPosition;
    [SerializeField]
    private float moveSpeed = 2f;
    
    void OnEnable() {
        if (!CameraSettings.cs) {
            CameraSettings.cs = this;
        } else {
            Destroy(this);
        }

        cam = this.gameObject.transform;
        if(GameObject.FindGameObjectWithTag("CameraPosition")) {
            targetPosition = GameObject.FindGameObjectWithTag("CameraPosition").transform.position;
        } else {
            targetPosition = Vector3.zero;
        }
        targetPosition.y = cameraHeight;

        cam.transform.position = targetPosition;
    }

    private void Update() {
        MoveCamera();
    }

    void MoveCamera() {
        cam.position = Vector3.Lerp(transform.position,
            cs.targetPosition,
            Time.deltaTime * moveSpeed);
    }
}
