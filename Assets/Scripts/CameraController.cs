using FishNet.Object;
using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private void Awake()
    {
        FirstObjectNotifier.OnFirstObjectSpawned += OnFirstObjectSpawned;
    }

    private void OnFirstObjectSpawned(Transform transform)
    {
        CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();

        virtualCamera.Follow = transform;
        virtualCamera.LookAt = transform;
    }

    private void OnDestroy()
    {
        FirstObjectNotifier.OnFirstObjectSpawned -= OnFirstObjectSpawned;
    }
}