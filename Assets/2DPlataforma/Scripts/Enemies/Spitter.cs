using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Spitter : MonoBehaviour
{
    [SerializeField]
    private Animator enemySpriteAnimator;

    [SerializeField]
    private float enemySightDistance;

    private Mover mover;
    private SpitShooter spitShooter;

    private IEnumerator walkCoroutine;
    private bool isSeeingPlayer;

    private void Start()
    {
        spitShooter = GetComponent<SpitShooter>();
        mover = GetComponent<Mover>();
        mover.OnChangeDirection += ChangeDirection;

        walkCoroutine = Walk();
        StartCoroutine(walkCoroutine);
    }

    private void Update()
    {
        isSeeingPlayer = CheckEnemySight();
    }

    public void Kill()
    {
        StartCoroutine(SecondsToKill());
    }

    private IEnumerator SecondsToKill()
    {
        StopCoroutine(walkCoroutine);
        mover.IsActive = false;

        enemySpriteAnimator.SetTrigger("Death");
        GetComponentInChildren<Collider2D>().enabled = false;

        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }

    private bool CheckEnemySight()
    {
        bool value = false;
        float directionHorizontalEnemy = enemySpriteAnimator.gameObject.transform.localScale.x;

        Vector3 direction = Vector3.right * directionHorizontalEnemy;
        Vector3 position = enemySpriteAnimator.transform.position + (Vector3.up * .5f) + (Vector3.right * directionHorizontalEnemy);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, enemySightDistance);

        Debug.DrawRay(position, direction * enemySightDistance, Color.blue);

        if(hit.collider != null)
        {
            if(hit.collider.TryGetComponent<Player>(out _))
            {
                value = true;
            }
        }

        return value;
    }

    private void ChangeDirection(int direction)
    {
        enemySpriteAnimator.gameObject.transform.localScale = new Vector3(direction, 1);
    }

    private IEnumerator Walk()
    {
        while (true)
        {
            if(isSeeingPlayer)
            {
                mover.IsActive = false;
                enemySpriteAnimator.SetBool("Walk", false);

                yield return new WaitForSeconds(.3f);
                enemySpriteAnimator.SetTrigger("Attack");
                spitShooter.Shot(enemySpriteAnimator.gameObject.transform.localScale.x);

                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
                mover.IsActive = true;
                enemySpriteAnimator.SetBool("Walk", true);
            }
        }
    }
}
