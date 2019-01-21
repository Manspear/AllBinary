using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFaceCamera : MonoBehaviour {

    public string filterCameraName = "ARCamera";
    public float strength = 0.5f;
    private Camera ARCamera;

    GameObject target;
    private void Start()
    {
        Camera[] foundObjects = FindObjectsOfType<Camera>();

        foreach (Camera asd in foundObjects)
        {
            if (asd.name == filterCameraName)
                ARCamera = asd;
        }
    }

    // Update is called once per frame
    void Update () {
        Quaternion targetRotation = Quaternion.LookRotation(ARCamera.transform.position - transform.position, new Vector3(0,1,0));
        float str = Mathf.Min(strength * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
    }
}
