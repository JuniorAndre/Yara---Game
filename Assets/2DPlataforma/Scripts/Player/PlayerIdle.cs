using UnityEngine;

public class PlayerIdle : PlayerStateMachine
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.CheckHorizontalMovementControl();
        player.FlipCharacter();

        player.CheckAttack();

        player.CheckJump();
        player.VerticalMovementControl();
        player.CheckPlayerGrounding();
    }
}