using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {

    public GameObject glitch;

    private Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - glitch.transform.position;
    }

    void LateUpdate()
    {
        transform.position = glitch.transform.position + cameraOffset;
    }
}


