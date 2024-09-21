using TPlus.StateMachine;

public abstract class PlayerLocomotionState : State_Base
{
    protected PlayerMovementInfo _movementInfo;
    protected float _speed;
    
    public PlayerLocomotionState(StateMachine_Base stateMachine, PlayerMovementInfo info) : base(stateMachine)
    {
        _movementInfo = info;
    }
}
