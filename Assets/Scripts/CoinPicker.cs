using UnityEngine;
using UnityEngine.UI;

public class CoinPicker : MonoBehaviour
{
    public TriggerProvider CoinToucher;
    public Text CoinCounter;

    int _coinCount;

    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        CoinToucher.Triggered += HandleCoinTouch;
        _coinCount = 0;
        CoinCounter.text = "0";
    }


    void HandleCoinTouch(Collider2D collider)
    {
        string tag = collider.gameObject.tag;
        Destroy(collider.gameObject);
        _coinCount++;
        CoinCounter.text = _coinCount.ToString();
    }
}