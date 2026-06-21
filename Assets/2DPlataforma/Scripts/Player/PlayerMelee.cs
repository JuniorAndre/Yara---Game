using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField]
    private GameObject meleeHitBox;

    private void Start()
    {
        EnableAttack(false);
    }

    public void EnableAttack(bool value) => meleeHitBox.SetActive(value);
}
