using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class Door : MonoBehaviour
{
    public event Action OnOpenDoor;

    private Animator animator;
    private bool isActivated;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isActivated = false;
    }

    internal void Activate()
    {
        animator.SetTrigger("Open");
        isActivated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActivated)
            return;

        if(collision.TryGetComponent<Player>(out _))
        {
            OnOpenDoor?.Invoke();
        }
    }
}
