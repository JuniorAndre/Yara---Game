using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damager : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private bool InactivateOnCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;

        if(InactivateOnCollision)
            gameObject.SetActive(false);

        if (collision.TryGetComponent<Damageable>(out Damageable damageable))
            damageable.Hit(damage);
    }
}
