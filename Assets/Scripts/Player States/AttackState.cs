using UnityEngine;

public class AttackState : State
{
    protected float attackSpeed;
    protected float attackDamage;

    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        attackSpeed = 3;
        attackDamage = 1;
        base.Enter();
        mouseLeftClick = 0.0f;

        Debug.Log("entering attack state");
        player.sr.color = new Color(0.6f, 0.2f, 0.9f);
    }

    public override void Exit()
    {
        Debug.Log("exiting attack state");

        base.Exit();
    }

    public override void Update()
    {
        if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f)
        {
            sm.ChangeState(sm.runState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }


        UIscript.ui.DrawText("*** This is the attack state ***\n");
        UIscript.ui.DrawText("Space = Jump State");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("C = Start the coroutine");
        UIscript.ui.DrawText("Left Click = Attack state");


    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in attackstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in attackstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
