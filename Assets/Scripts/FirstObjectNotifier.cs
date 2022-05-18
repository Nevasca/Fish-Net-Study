using FishNet.Object;
using System;
using System.Collections;
using UnityEngine;

public class FirstObjectNotifier : NetworkBehaviour
{
    public static event Action<Transform> OnFirstObjectSpawned;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!IsOwner)
            return;

        NetworkObject nob = LocalConnection.FirstObject;
        if (nob == NetworkObject)
            OnFirstObjectSpawned?.Invoke(transform);
    }
}