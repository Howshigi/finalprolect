using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private int coin = 0;

    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coin++;
            coinText.text = "Coin: " + coin.ToString();
            Debug.Log("Coins collected: " + coin);
            Destroy(other.gameObject);
        }
    }
}