using System;
using UnityEngine;

public class HitFromPlayerDetector : MonoBehaviour
{
    public event Action PlayerHitsFromSide;
    public event Action PlayerHitsFromAbove;
    public event Action PlayerHitsFromBelow;

    float _playerXCoordMin;
    float _playerXCoordMax;

    // Start is called before the first frame update
    void Start()
    {
        float thisX = this.transform.position.x;
        _playerXCoordMin = thisX - this.transform.lossyScale.x;
        _playerXCoordMax = thisX + this.transform.lossyScale.x;
    }

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject;
            float playerX = player.transform.position.x;
            bool playerHitsInXBounds = _playerXCoordMin < playerX && playerX < _playerXCoordMax;

            if (!playerHitsInXBounds)
            {
               PlayerHitsFromSide?.Invoke();
            }
            else/* if (playerHitsInXBounds)*/
            {
                float playerY = player.transform.position.y;
                bool playerHitsFromBelow = playerY < this.transform.position.y;

                if(playerHitsFromBelow)
                    PlayerHitsFromBelow?.Invoke();
                else
                    PlayerHitsFromAbove?.Invoke();
            }
        }
    }
}