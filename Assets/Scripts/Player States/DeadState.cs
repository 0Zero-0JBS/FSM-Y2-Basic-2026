using UnityEngine;

public class DeadState : State
{
    public DeadState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering dead state");

    }

    public override void Exit()
    {

    }

}