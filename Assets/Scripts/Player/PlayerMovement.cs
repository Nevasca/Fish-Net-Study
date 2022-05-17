using FishNet.Object;
using System.Collections;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float Speed = 5f;

    private CharacterController _characterController;
    private PlayerAnimation _playerAnimation;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (!IsOwner)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 offset = new Vector3(horizontal, Physics.gravity.y, vertical) * (Speed * Time.deltaTime);

        _characterController.Move(offset);

        bool isMoving = horizontal != 0f || vertical != 0f;
        _playerAnimation.SetMoving(isMoving);

        if (Input.GetKeyDown(KeyCode.Space))
            _playerAnimation.Jump();
    }

    [Client(RequireOwnership = true)]
    private void ExecuteOnlyIfOwner()
    {
        Debug.Log("I'm the owner of this object!");
    }
}