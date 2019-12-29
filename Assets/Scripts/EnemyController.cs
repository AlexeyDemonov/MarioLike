using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HitFromPlayerDetector))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public float Speed;
    public float CycleEveryXSeconds;
    public int MaxIdleCycles;
    public GroundChecker LeftArm;
    public GroundChecker RightArm;
    public GroundChecker LeftLeg;
    public GroundChecker RightLeg;

    bool _goingLeft;
    int _idleXCycles;
    int _idleCounter;
    WaitForSeconds _interCycleWait;
    HitFromPlayerDetector _hitDetector;
    Coroutine _cycleCoroutine;
    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _goingLeft = Random.Range(0, 2) == 0 ? true : false;

        _interCycleWait = new WaitForSeconds(CycleEveryXSeconds);

        _hitDetector = GetComponent<HitFromPlayerDetector>();
        _hitDetector.PlayerHitsFromAbove += HandleHitFromAbove;
        _hitDetector.PlayerHitsFromSide += HandlePlayerTouchFromSide;

        _rigidbody = GetComponent<Rigidbody2D>();

        _cycleCoroutine = StartCoroutine(RunMoveCycles());
    }

    void HandleHitFromAbove()
    {
        StopCoroutine(_cycleCoroutine);
        GetComponent<Collider2D>().enabled = false;
    }

    void HandlePlayerTouchFromSide()
    {
        (GameObject.FindGameObjectWithTag("Player")?.GetComponent(typeof(PlayerDamager)) as PlayerDamager)?.HandleDamage();
    }

    IEnumerator RunMoveCycles()
    {
        while (true)
        {
            _idleCounter = 0;
            _idleXCycles = Random.Range(1, MaxIdleCycles + 1);

            while (_idleCounter < _idleXCycles)
            {
                _idleCounter++;
                yield return _interCycleWait;
            }

            if (_goingLeft)
            {
                while (!LeftArm.IsGrounded && LeftLeg.IsGrounded)
                {
                    _rigidbody.velocity = Vector2.left * Speed;
                    yield return _interCycleWait;
                }
            }
            else
            {
                while (!RightArm.IsGrounded && RightLeg.IsGrounded)
                {
                    _rigidbody.velocity = Vector2.right * Speed;
                    yield return _interCycleWait;
                }
            }

            _goingLeft = !_goingLeft;//Swap direction
            _rigidbody.velocity = Vector2.zero;
        }
    }
}