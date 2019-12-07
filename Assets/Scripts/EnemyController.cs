using UnityEngine;

[RequireComponent(typeof(HitFromPlayerDetector))]
[RequireComponent(typeof(Collider2D))]
public class EnemyController : MonoBehaviour
{
    public float Speed;
    public float IdleTimeMin;
    public float IdleTimeMax;
    public GroundChecker[] GroundCheckers;

    bool _goingLeft;
    HitFromPlayerDetector _hitDetector;

    // Start is called before the first frame update
    void Start()
    {
        _goingLeft = Random.Range(0, 2) == 0 ? true : false;

        _hitDetector = GetComponent<HitFromPlayerDetector>();
        _hitDetector.PlayerHitsFromAbove += HandleHitFromAbove;
        _hitDetector.PlayerHitsFromSide += HandlePlayerTouchFromSide;
    }

    void HandleHitFromAbove()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    void HandlePlayerTouchFromSide()
    {
        (GameObject.FindGameObjectWithTag("Player")?.GetComponent(typeof(PlayerDamager)) as PlayerDamager)?.HandleDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}