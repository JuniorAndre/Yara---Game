using UnityEngine;

public class PlayerDeath : PlayerStateMachine
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.VerticalMovementControl();
        player.CheckPlayerGrounding();
    }
}
