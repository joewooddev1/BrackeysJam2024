using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicalGrabInteractable : MonoBehaviour
{
    private Transform interactionConnectPoint;
    private ConfigurableJoint attachJoint;

    // Start is called before the first frame update
    void Start()
    {
        interactionConnectPoint = GameObject.Find("PhysicsBasedGrabPoint").transform;   
    }

    public void AttachToGrab() 
    {
        if (attachJoint == null) { attachJoint = gameObject.AddComponent<ConfigurableJoint>(); }

        JointDrive xJD = attachJoint.xDrive;
        JointDrive yJD = attachJoint.yDrive;
        JointDrive zJD = attachJoint.zDrive;

        xJD.positionSpring = 250f;
        yJD.positionSpring = 250f;
        zJD.positionSpring = 250f;

        xJD.positionDamper = 50f;
        yJD.positionDamper = 50f;
        zJD.positionDamper = 50f;

        attachJoint.xDrive = xJD;
        attachJoint.yDrive = yJD;
        attachJoint.zDrive = zJD;

        attachJoint.angularXDrive = xJD;
        attachJoint.angularYZDrive = yJD;

        attachJoint.connectedBody = interactionConnectPoint.GetComponent<Rigidbody>();
    }

    public void DropFromGrab() 
    {
        DestroyImmediate(attachJoint);
    }
}
