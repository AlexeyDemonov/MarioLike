using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerController))]
public class PlayerDamager : MonoBehaviour
{
    private void Awake()
    {
        EnemyController.PlayerHitted += HandleDamage;
    }

    private void OnDestroy()
    {
        EnemyController.PlayerHitted -= HandleDamage;
    }

    public void HandleDamage()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
    }
}