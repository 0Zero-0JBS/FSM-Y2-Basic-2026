using UnityEngine;

public class CrouchState : State
{
    float crouchSpeed;
    float crouchRotationSpeed;

    public CrouchState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

}
