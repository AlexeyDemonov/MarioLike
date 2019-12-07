using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public float GroundDistance;

    public bool IsGrounded
    {
        get
        {
            var hit = Physics2D.Raycast(this.transform.position, -this.transform.up, GroundDistance);
            return hit.collider != null;
        }
    }
}