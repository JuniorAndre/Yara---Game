using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerGrounding))]
[RequireComponent (typeof(PlayerMelee))]
[RequireComponent(typeof(PlayerSoundController))]
public class Player : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField]
    private CinemachineCamera virtualCamera;

    [SerializeField]
    private float speedX = 5;

    [SerializeField] 
    private float jumpForce = 600;

    private Animator animator;
    private new Rigidbody2D rigidbody2D;
    private PlayerGrounding playerGrounding;
    private PlayerMelee playerMelee;
    private PlayerSoundController soundController;

    private float directionX;
    private bool isJump;
    private bool isDead;

    private void Start()
    {
        virtualCamera.Follow = transform;

        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerGrounding = GetComponent<PlayerGrounding>();
        playerMelee = GetComponent<PlayerMelee>();
        soundController = GetComponent<PlayerSoundController>();
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            soundController.Play(soundController.JumpFX);
            rigidbody2D.AddForce(Vector2.up * jumpForce);
            isJump = false;
        }
        rigidbody2D.linearVelocity = new Vector2(directionX * speedX, rigidbody2D.linearVelocity.y);
        directionX = 0;
    }

    public void CheckHorizontalMovementControl()
    {
        directionX = Input.GetAxis("Horizontal");
        animator.SetFloat("SpeedX", Mathf.Abs(directionX));
    }

    public void FlipCharacter()
    {
        if(directionX > 0)
            transform.localScale = new Vector2(1, 1);

        if (directionX < 0)
            transform.localScale = new Vector2(-1, 1);
    }
    
    public void CheckPlayerGrounding()
    {
        animator.SetBool("IsGrounded", playerGrounding.IsGrounded);
    }

    public void CheckJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
            rigidbody2D.gravityScale = 2;
        }
    }

    public void VerticalMovementControl()
    {
        if (Input.GetButtonUp("Jump"))
        {
            rigidbody2D.gravityScale = 4;
        }

        animator.SetFloat("SpeedY", rigidbody2D.linearVelocity.y);
    }

    public void CheckAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
            soundController.Play(soundController.AttackFX);

            StartCoroutine(EnableMeleeCollisions());
        }
    }

    private IEnumerator EnableMeleeCollisions()
    {
        yield return new WaitForSeconds(.13f);
        playerMelee.EnableAttack(true);

        yield return new WaitForSeconds(.3f);
        playerMelee.EnableAttack(false);
    }

    public void Kill()
    {
        if(isDead) 
            return;

        virtualCamera.Follow = null;

        isDead = true;

        animator.SetTrigger("Death");
        soundController.Play(soundController.DeathFX);

        directionX = 0;
        rigidbody2D.linearVelocity = Vector2.zero;
        rigidbody2D.AddForce(Vector2.up * 500);

        StartCoroutine(DeathAfterSeconds());
    }

    public IEnumerator DeathAfterSeconds()
    {
        yield return new WaitForSeconds(3);

        OnDeath?.Invoke();
    }

    public void ResetToRevive()
    {
        isDead = false;

        virtualCamera.Follow = transform;

        animator.SetTrigger("Revive");
        transform.localScale = new Vector3(1, 1);
        rigidbody2D.linearVelocity = Vector2.zero;
    }
}
