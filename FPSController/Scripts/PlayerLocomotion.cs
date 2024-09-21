using TPlus.StateMachine;
using UnityEngine;

public class PlayerLocomotion : StateMachine_Base
{
    private PlayerMovementInfo _movementInfo;
    
    public readonly PLS_Standard StandardMoveState;
    
    public PlayerLocomotion(HFSM_Base hfsm, PlayerMovementInfo info) : base(hfsm)
    {
        _movementInfo = info;
        StandardMoveState = new PLS_Standard(this, info);
        ChangeState(StandardMoveState);
    }

    public override void OnStateEnter()
    {
        Debug.Log("Initializing player locomotion");
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting player locomotion state machine");
    }
}

public class PlayerMovementInfo
{
    public float RunSpeed {get; private set;}
    public float SprintSpeed {get; private set;}
    public float JumpForce {get; private set;}
    public float GroundDrag {get; private set;}
    public float AirDrag {get; private set;}
    public Transform Orientation;
    public Rigidbody RB {get; private set;}

    public PlayerMovementInfo(float runSpeed, float sprintSpeed, float jumpForce, float groundDrag,
        float airDrag, Transform orientation, Rigidbody rb)
    {
        RunSpeed = runSpeed;
        SprintSpeed = sprintSpeed;
        JumpForce = jumpForce;
        GroundDrag = groundDrag;
        AirDrag = airDrag;
        Orientation = orientation;
        RB = rb;
    }
}
