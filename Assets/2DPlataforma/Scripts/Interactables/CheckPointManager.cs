using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Transform LastPassedCheckPoint { get; private set; }

    public void UpdateLastPassedCheckPoint(Transform checkPoint)
    {
        LastPassedCheckPoint = checkPoint;
    }

}
