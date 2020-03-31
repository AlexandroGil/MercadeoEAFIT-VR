using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {

    //public bool debug;
    [SerializeField]
    //private float range = 100f;


    private bool isLooking;
    private float lookTimer;

    [SerializeField]
    private float watchTime = 3f;
    [SerializeField]
    private float cooldownTime = 5f;

    [SerializeField]
    private LayerMask doorHitMask;
    private GameObject hit;

    [SerializeField]
    private float cooldownTimer;
    private bool isInCooldown;

    // Update is called once per frame
    void Update() {

        //CheckRaycast();
        CountLook();
        CheckCooldownTimer();

        //if (debug) {
        //    Debug.DrawRay(transform.position,transform.forward * 20,Color.red,1f);
        //}
        

    }

    public void StartCounter() {
        isLooking = true;
        
        
    }

    void CountLook() {
        if (isLooking) {
            lookTimer += Time.deltaTime;
            if(lookTimer >= watchTime) {
                if(hit.transform.GetComponent<PortalDoor>() != null) {
                    Debug.Log("Hit Door");
                    if (!isInCooldown) {
                        PortalDoor door = hit.transform.GetComponent<PortalDoor>();
                        door.StartMovement(true);
                        isInCooldown = true;

                        ResetCounter();
                    }
                }
            }
        }
    }

    void CheckCooldownTimer() {
        if (isInCooldown) {
            cooldownTimer += Time.deltaTime;
            if(cooldownTimer>= cooldownTime) {
                isInCooldown = false;

                ResetCooldown();
            }
        }
    }

    public void ResetCounter() {
        isLooking = false;
        lookTimer = 0;
    }

    void ResetCooldown() {
        cooldownTimer = 0;
    }

    //private void OnDrawGizmos(){
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range);
    //}

    public void SetHitTarget(GameObject hit) {
        this.hit = hit;
    }
}
