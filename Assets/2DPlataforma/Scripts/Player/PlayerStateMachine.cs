using UnityEngine;

public class PlayerStateMachine : StateMachineBehaviour
{
    protected Player player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.GetComponentInParent<Player>();
        }
    }
}
