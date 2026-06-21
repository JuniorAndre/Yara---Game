using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private CheckPointManager checkPointManager;

    [SerializeField]
    private Door door;

    private Vector3 initialPlayerPosition;

    [SerializeField]
    private string nextLevelName;

    private void Start()
    {
        Physics2D.queriesHitTriggers = false;

        initialPlayerPosition = player.transform.position;
        player.OnDeath += OnPlayerDeath;

        door.OnOpenDoor += OnOpenDoor;
    }

    private void OnOpenDoor()
    {
        StopAllCoroutines();
        SceneManager.LoadScene(nextLevelName);
    }

    private void OnPlayerDeath()
    {
        player.ResetToRevive();
        SendPlayerToCheckPoint();
    }

    private void SendPlayerToCheckPoint()
    {
        if(checkPointManager.LastPassedCheckPoint != null)
        {
            player.transform.position = checkPointManager.LastPassedCheckPoint.position;
        }
        else
        {
            player.transform.position = initialPlayerPosition;
        }
        
    }
}
