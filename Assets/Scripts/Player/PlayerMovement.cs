using FishNet.Object;
using System.Collections;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float Speed = 5f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!IsOwner)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 offset = new Vector3(horizontal, Physics.gravity.y, vertical) * (Speed * Time.deltaTime);

        _characterController.Move(offset);
    }

    [Client(RequireOwnership = true)]
    private void ExecuteOnlyIfOwner()
    {
        Debug.Log("I'm the owner of this object!");
    }
}