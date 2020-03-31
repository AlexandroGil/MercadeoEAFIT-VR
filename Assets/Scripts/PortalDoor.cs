using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoor : MonoBehaviour {

    public PortalDoor exitPortal;
    public Transform thisSphereCenter;
    

    [Header("Debug")]
    public bool debug = false;

    void Update() {
        if (debug) {
            MoveCamera();
        }
    }

    void MoveCamera() {
        Vector3 posToMove = this.transform.position;
        posToMove += -this.transform.forward * 4;
        posToMove.y += CameraSettings.cs.cameraHeight;
        CameraSettings.cs.targetPosition = posToMove;

        exitPortal.thisSphereCenter.transform.parent.gameObject.SetActive(true);
        debug = false;
    }

    public void StartMovement(bool move) {
        debug = move;
    }

    
}
