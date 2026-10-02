//This is a derived class of State
//This means it inherits fields and methods from State.cs


using UnityEngine;

public class JumpState : State
{
    protected float jumpForce;

    public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        player.anim.SetBool("isJumping", true);
        jumpForce = 3;
        base.Enter();
        verticalInput = 0.0f;
        player.rb.linearVelocity = new Vector2(0, player.rb.linearVelocity.y);

        Debug.Log("entering jumping state");

        player.sr.color = new Color(0.8f, 0.3f, 0.4f);  //change the sprite colour
    }

    public override void Exit()
    {
        player.anim.SetBool("isJumping", false);
        Debug.Log("exiting jump state");

        base.Exit();//exit the jump state
    }

    public override void Update()
    {
        ReadInput();

        Vector2 jumpInput = player.moveAction.ReadValue<Vector2>();

        if (jumpInput.magnitude <= 0.01f)
        {
            player.rb.linearVelocity = Vector2.zero;
            sm.ChangeState(sm.idleState);
        }

        if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f )
        {
            sm.ChangeState(sm.runState);
        }

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }

        UIscript.ui.DrawText("*** This is the jumping state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Space = Jump state");
        UIscript.ui.DrawText("Left Click = Attack state");

    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in jumpstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in jumpstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();//Fixed Update 
    }
}
