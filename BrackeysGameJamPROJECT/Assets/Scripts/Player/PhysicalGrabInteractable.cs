using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (Interaction))]
public class PhysicalGrabInteractable : MonoBehaviour
{
    private Transform interactionConnectPoint;
    private ConfigurableJoint attachJoint;

    private Rigidbody thisRB;

    // Start is called before the first frame update
    void Start()
    {
        interactionConnectPoint = GameObject.Find("PhysicsBasedGrabPoint").transform;

        TryGetComponent(out thisRB);
    }

    public void AttachToGrab() 
    {
        if (attachJoint == null) { attachJoint = gameObject.AddComponent<ConfigurableJoint>(); }

        JointDrive xJD = attachJoint.xDrive;
        JointDrive yJD = attachJoint.yDrive;
        JointDrive zJD = attachJoint.zDrive;

        xJD.positionSpring = 250f * thisRB.mass;
        yJD.positionSpring = 250f * thisRB.mass;
        zJD.positionSpring = 250f * thisRB.mass;

        xJD.positionDamper = 25f * thisRB.mass;
        yJD.positionDamper = 25f * thisRB.mass;
        zJD.positionDamper = 25f * thisRB.mass;

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
