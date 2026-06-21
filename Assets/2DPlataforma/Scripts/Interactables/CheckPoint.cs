using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteOn;

    [SerializeField]
    private Transform spawnTransform;

    private CheckPointManager checkPointManager;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        checkPointManager = GetComponentInParent<CheckPointManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out _))
        {
            if(spriteRenderer.sprite != spriteOn)
            {
                spriteRenderer.sprite = spriteOn;
                checkPointManager.UpdateLastPassedCheckPoint(spawnTransform);
            }
            
        }
    }
}
