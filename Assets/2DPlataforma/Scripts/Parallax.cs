using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    [SerializeField] private Transform cam;
    private Vector3 lastCamPos;

    void Start()
    {
        lastCamPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, deltaMovement.y * parallaxEffect, 0);
        lastCamPos = cam.position;
    }
}