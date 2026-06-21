using UnityEngine;

public class FootStepsAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private PlayerSoundController soundController;

    public void PlayFootStepsSound()
    {
        soundController.Play(soundController.FootStepsFX);
    }
}
