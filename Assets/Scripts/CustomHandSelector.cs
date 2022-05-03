using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class CustomHandSelector : MonoBehaviour
{
    public Transform pistol;
    OVRCameraRig m_CameraRig;
    OVRInputModule m_InputModule;

    void Start()
    {
        m_CameraRig = FindObjectOfType<OVRCameraRig>();
        m_InputModule = FindObjectOfType<OVRInputModule>();

        if(OVRInput.GetActiveController() == OVRInput.Controller.LTouch)
        {
            SetActiveController(OVRInput.Controller.LTouch);
        }
        else
        {
            SetActiveController(OVRInput.Controller.RTouch);
        }
    }

    void SetActiveController(OVRInput.Controller c)
    {
        Transform t;
        if(c == OVRInput.Controller.LTouch)
        {
            t = m_CameraRig.leftHandAnchor;
        }
        else
        {
            t = m_CameraRig.rightHandAnchor;
        }
        m_InputModule.rayTransform = t;
    }

    public void SetAnchor(Transform anchor)
    {
        m_InputModule.rayTransform = anchor;
        if(anchor == m_CameraRig.leftHandAnchor)
        {
            pistol.rotation *= new Quaternion(180f, 0f, 0f, 1f);
        }
    }
}