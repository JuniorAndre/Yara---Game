using UnityEngine;

public class PlayerAttack : PlayerStateMachine
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.VerticalMovementControl();
        player.CheckPlayerGrounding();
    }
}
