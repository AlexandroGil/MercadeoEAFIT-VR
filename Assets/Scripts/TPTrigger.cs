using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPTrigger : MonoBehaviour {

    private PortalDoor pDoor;
    
    


    void OnEnable() {
        pDoor = transform.parent.GetComponent<PortalDoor>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "MainCamera") { 
            Vector3 tpPosition = pDoor.exitPortal.transform.position;
            tpPosition += pDoor.exitPortal.transform.forward * CameraSettings.cs.colliderSize;
            tpPosition.y += CameraSettings.cs.cameraHeight;

            other.transform.position = tpPosition;
            pDoor.StartMovement(false);

            CameraSettings.cs.targetPosition = pDoor.exitPortal.thisSphereCenter.position;
            pDoor.thisSphereCenter.parent.gameObject.SetActive(false);

           
            

        }
    }

    
}
