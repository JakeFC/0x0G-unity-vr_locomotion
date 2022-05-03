using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunBehavior : MonoBehaviour
{
    public Transform leftHandAnchor;
    public Transform rightHandAnchor;
    public GameObject UIHelpers;
    public enum ParentObject
    {
        LeftHand,
        RightHand,
        None,
    }
    private ParentObject _parentObject;
    private Transform _oldParent = null;
    private Transform _newParent;
    public ParentObject parentObject
    {
        set
        {
            if (_parentObject != value)
            {
                if (value == ParentObject.LeftHand)
                    UIHelpers.GetComponent<CustomHandSelector>().SetAnchor(leftHandAnchor);
                if (value == ParentObject.RightHand || value == ParentObject.None)
                    UIHelpers.GetComponent<CustomHandSelector>().SetAnchor(rightHandAnchor);
            }
            _parentObject = value;
        }
        get
        {
            return _parentObject;
        }
    }

    void Start()
    {
        if (_parentObject != ParentObject.None)
            if (_parentObject == ParentObject.LeftHand)
                UIHelpers.GetComponent<CustomHandSelector>().SetAnchor(leftHandAnchor);
            else
                UIHelpers.GetComponent<CustomHandSelector>().SetAnchor(rightHandAnchor);
    }

    // Update is called once per frame
    void Update()
    {
        _newParent = transform.parent.transform;
        if (_newParent != _oldParent)
            if (_newParent == leftHandAnchor)
                parentObject = ParentObject.LeftHand;
            else if (_newParent == rightHandAnchor)
                parentObject = ParentObject.RightHand;
            else
                parentObject = ParentObject.None;
    }
}
