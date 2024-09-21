using TPlus.StateMachine;
using UnityEngine;

public class PLS_Standard : PlayerLocomotionState
{
    public PLS_Standard(StateMachine_Base stateMachine, PlayerMovementInfo info) : base(stateMachine, info)
    {
    }

    public override void OnStateEnter()
    {
        InputManager.Instance.OnJumpButtonPressed += Jump;
        _speed = _movementInfo.RunSpeed;
        _movementInfo.RB.drag = _movementInfo.GroundDrag;
    }

    public override void StateUpdate()
    {
        Move();
    }

    private void Move()
    {
        var inputDir = InputManager.Instance.GetMoveVector();
        var moveVector = _movementInfo.Orientation.forward * inputDir.y + _movementInfo.Orientation.right * inputDir.x;
        var appliedDir = moveVector.normalized * _speed;
        _movementInfo.RB.AddForce(appliedDir * _speed, ForceMode.Force);
        LimitVelocity();
    }

    private void LimitVelocity()
    {
        var curVelocity = _movementInfo.RB.velocity;
        var xzVelocity = new Vector3(curVelocity.x, 0, curVelocity.z);
        if (xzVelocity.magnitude > _speed)
        {
            var newVelocity = curVelocity.normalized;
            newVelocity *= _speed;
            newVelocity.y = curVelocity.y;
            _movementInfo.RB.velocity = newVelocity;
        }
    }

    public override void OnStateExit()
    {
        InputManager.Instance.OnJumpButtonPressed -= Jump;
    }
    
    private void Jump()
    {
        _movementInfo.RB.AddForce(_movementInfo.Orientation.up * _movementInfo.JumpForce, ForceMode.Impulse);
    }
}
