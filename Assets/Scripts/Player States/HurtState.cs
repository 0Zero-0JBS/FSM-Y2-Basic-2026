using UnityEngine;

public class HurtState : State
{
    public HurtState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering hurt state");

    }

    public override void Exit()
    {

    }

}
