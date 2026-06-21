using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public event Action<int> OnChangeDirection;
    public bool IsActive {  get; set; }

    [SerializeField]
    private Transform position1, position2;

    [SerializeField]
    private Transform objectToMove;

    [SerializeField]
    private float timeToReachDestiny = 1;

    private float timePassed;
    private Vector3 startPosition, finalPosition;

    private void Start()
    {
        IsActive = true;

        timePassed = 0;

        startPosition = position1.position;
        finalPosition = position2.position;
    }

    private void Update()
    {
        if(IsActive)
            timePassed += Time.deltaTime/timeToReachDestiny;

        objectToMove.transform.position = Vector2.Lerp(startPosition, finalPosition, timePassed);

        ChangeDirectionWhenReachDestiny();
    }

    private void ChangeDirectionWhenReachDestiny()
    {
        if(timePassed > 1)
        {
            if(startPosition == position1.position)
            {
                OnChangeDirection?.Invoke(-1);
                startPosition = position2.position;
                finalPosition = position1.position;
            }
            else
            {
                OnChangeDirection?.Invoke(1);
                startPosition = position1.position;
                finalPosition = position2.position;
            }
            timePassed = 0;
        }
    }
}
