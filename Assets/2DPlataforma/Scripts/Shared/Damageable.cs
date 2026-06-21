using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent OnDamage;
    public UnityEvent OnKill;

    [SerializeField]
    private int life;

    public void Hit(int damage)
    {
        life -= damage;
        if(life > 0)
        {
            OnDamage?.Invoke();
        }
        else
        {
            OnKill?.Invoke();
        }
    }
}
