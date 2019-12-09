using UnityEngine;

[RequireComponent(typeof(HitFromPlayerDetector))]
public class ChestController : MonoBehaviour
{
    public Animator ChestAnimator;
    public string TriggerName;

    [Space(5)]
    public GameObject Coin;

    public int CoinsInside;
    public float CoinYLaunchForce;
    public float CoinXLaunchSpread;

    int _coinCount;
    Vector3 _coinInstantiatePos;

    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        _coinCount = CoinsInside;
        _coinInstantiatePos = new Vector3(
            this.transform.position.x,
            this.transform.position.y + (this.transform.lossyScale.y / 2),
            this.transform.position.z);

        GetComponent<HitFromPlayerDetector>().PlayerHitsFromBelow += HandlePlayerHitFromBelow;
    }

    void HandlePlayerHitFromBelow()
    {
        if (_coinCount > 0)
        {
            ChestAnimator.SetTrigger(TriggerName);

            var instance = Instantiate<GameObject>(Coin, _coinInstantiatePos, Quaternion.identity);
            var coinRB = instance.GetComponent<Rigidbody2D>();
            coinRB.AddForce(
                new Vector2(Random.Range((CoinXLaunchSpread * -1), CoinXLaunchSpread), CoinYLaunchForce),
                ForceMode2D.Impulse);

            _coinCount--;
        }
    }
}