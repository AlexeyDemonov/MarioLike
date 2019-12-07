using System;
using UnityEngine;

public class TriggerProvider : MonoBehaviour
{
    public event Action<Collider2D> Triggered;

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Triggered?.Invoke(collision);
    }
}