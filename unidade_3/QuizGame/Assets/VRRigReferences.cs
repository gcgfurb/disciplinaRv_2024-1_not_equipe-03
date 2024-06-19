using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRigReferences : MonoBehaviour
{
    public static VRRigReferences Singleton;

    public Transform root;
    public Transform leftController;
    public Transform rightController;

    private void Awake()
    {
        Singleton = this;
    }
}
