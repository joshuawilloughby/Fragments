using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
    public CameraShake cameraShake;
    void OnCollisionEnter(Collision hit)
    {
        Debug.Log(hit.collider.name);
        if (hit.gameObject.name == "Grass")
        {
            Debug.Log("Camera Shaking");
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}
