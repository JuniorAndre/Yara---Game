using UnityEngine;

[RequireComponent(typeof(PlayerSoundController))]
public class PlayerGrounding : MonoBehaviour
{
    public bool IsGrounded {  get; private set; }

    private Transform groundMovingObject;
    private Vector3? groundMovObjectLastPosition;

    private PlayerSoundController soundController;

    private void Start()
    {
        soundController = GetComponent<PlayerSoundController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == true)
            return;

        IsGrounded = true;
        soundController.Play(soundController.LandFX);

        if(collision.GetComponentInParent<Mover>() != null)
        {
            groundMovingObject = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == true)
            return;

        IsGrounded = false;
        groundMovingObject = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(groundMovingObject != null)
        {
            if(groundMovObjectLastPosition.HasValue && groundMovObjectLastPosition.Value != groundMovingObject.position)
            {
                Vector3 delta = groundMovingObject.position - groundMovObjectLastPosition.Value;
                transform.position += delta;
            }
            groundMovObjectLastPosition = groundMovingObject.position;
        }
        else
        {
            groundMovObjectLastPosition = null;
        }
    }
}