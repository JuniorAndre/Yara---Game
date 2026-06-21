using UnityEngine;

public class PlayerJump : PlayerStateMachine
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.CheckHorizontalMovementControl();
        player.FlipCharacter();

        player.VerticalMovementControl();
        player.CheckPlayerGrounding();
    }
}
