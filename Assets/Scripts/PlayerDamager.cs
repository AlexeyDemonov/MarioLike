using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerController))]
public class PlayerDamager : MonoBehaviour
{
    public void HandleDamage()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
    }
}