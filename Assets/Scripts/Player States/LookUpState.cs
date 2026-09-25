using UnityEngine;

public class LookUpState : State
{
    float lookUpSpeed;

    public LookUpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

}
