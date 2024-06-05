using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    public Transform root;
    public Transform leftController;
    public Transform rightController;

    public Renderer[] meshToDisable;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsOwner)
        {
            return;
        }
        foreach (var item  in meshToDisable)
        {
            item.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        root.SetPositionAndRotation(VRRigReferences.Singleton.root.position, VRRigReferences.Singleton.root.rotation);
        leftController.SetPositionAndRotation(VRRigReferences.Singleton.leftController.position, VRRigReferences.Singleton.leftController.rotation);
        rightController.SetPositionAndRotation(VRRigReferences.Singleton.rightController.position, VRRigReferences.Singleton.rightController.rotation);
    }
}
