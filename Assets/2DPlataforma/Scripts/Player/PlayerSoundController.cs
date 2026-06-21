using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class PlayerSoundController : MonoBehaviour
{
    public AudioClip[] FootStepsFX { get => footSteps; }

    public AudioClip JumpFX { get => jump; }
    public AudioClip LandFX { get => land; }
    public AudioClip AttackFX { get => attack; }
    public AudioClip DeathFX { get => death; }

    [SerializeField]
    private AudioClip[] footSteps;

    [SerializeField]
    private AudioClip jump;

    [SerializeField]
    private AudioClip land;

    [SerializeField]
    private AudioClip attack;

    [SerializeField]
    private AudioClip death;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip[] clips)
    {
        int drawnClip = Random.Range(0, clips.Length);
        source.PlayOneShot(clips[drawnClip]);
    }

    public void Play(AudioClip clip) => source.PlayOneShot(clip);
}
