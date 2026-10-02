
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class RunState : State
{
    protected float speed;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        player.anim.SetBool("isRunning", true);
        speed = 3;
        base.Enter();
        horizontalInput = 0.0f;


        Debug.Log("entering running state");

        player.sr.color = new Color(0.8f, 0.8f, 0.2f);
    }

    public override void Exit()
    {
        player.anim.SetBool("isRunning", false);
        Debug.Log("exiting run state");

        base.Exit();
    }



    public override void Update()
    {

        TestMethod("hello");
        ReadInput();

        Vector2 moveInput = player.moveAction.ReadValue<Vector2>();

        if (moveInput.magnitude <= 0.01f)
        {
            player.rb.linearVelocity = Vector2.zero;
            sm.ChangeState(sm.idleState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }

        //debug move gameObject
        player.rb.linearVelocity = player.moveAction.ReadValue<Vector2>() * speed;


        UIscript.ui.DrawText("*** This is the running state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Space = Jump state");
        UIscript.ui.DrawText("Left Click = Attack state");



    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in runstate");

        if( collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in runstate");

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
