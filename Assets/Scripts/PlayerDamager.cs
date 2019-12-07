using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerDamager : MonoBehaviour
{
    public void HandleDamage()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}