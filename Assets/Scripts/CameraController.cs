using FishNet.Object;
using System.Collections;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!IsOwner)
            return;

        Camera cam = GetComponent<Camera>();
        cam.enabled = true;
    }
}