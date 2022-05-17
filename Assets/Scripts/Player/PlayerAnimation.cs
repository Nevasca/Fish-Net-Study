using FishNet.Component.Animating;
using FishNet.Object;
using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private NetworkAnimator _networkAnimator;

    private const string ANIM_MOVING = "moving";
    private const string ANIM_JUMP = "jump";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _networkAnimator = GetComponent<NetworkAnimator>();
    }

    public void SetMoving(bool value)
    {
        _animator.SetBool(ANIM_MOVING, value);
    }

    public void Jump()
    {
        _networkAnimator.SetTrigger(ANIM_JUMP);
    }
}