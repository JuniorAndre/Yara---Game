using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Key : MonoBehaviour
{
    [SerializeField]
    private Door door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out _))
        {
            gameObject.SetActive(false);
            door.Activate();
        }
    }
}
