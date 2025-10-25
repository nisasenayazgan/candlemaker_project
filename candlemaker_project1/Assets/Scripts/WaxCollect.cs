using UnityEngine;
using UnityEngine.UI;

public class WaxCollect : MonoBehaviour
{
    public Slider waxBar; // UI Slider
    public int waxAmount = 10; // bu wax kaç birim dolacak

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Wax barı artır
            if (waxBar != null)
            {
                waxBar.value += waxAmount;
            }

            // Wax objesini yok et
            Destroy(gameObject);
        }
    }
}
