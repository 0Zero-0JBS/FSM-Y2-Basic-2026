using UnityEngine;

public class AttackState : State
{
    float attackSpeed;
    float attackDamage;

    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

}
