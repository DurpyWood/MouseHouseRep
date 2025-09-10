using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomInOut : MonoBehaviour
{
    public float zoom;
    public float zoommult;
    public float minzoom;
    public float maxzoom;
    public float velocity;
    public float smoothtime;
    [SerializeField] private CinemachineFreeLook cam;
    void Start()
    {
        zoom = cam.m_Lens.FieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoommult;
        zoom = Mathf.Clamp(zoom, minzoom, maxzoom);
        cam.m_Lens.FieldOfView = Mathf.SmoothDamp(cam.m_Lens.FieldOfView, zoom, ref velocity, smoothtime);
    }
}