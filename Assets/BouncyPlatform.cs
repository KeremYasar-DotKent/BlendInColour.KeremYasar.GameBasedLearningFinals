using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [Header("Zýplama Ayarý")]
    public float bounceForce = 35f; // Yerçekimin güçlü olduðu için gücü 35 yaptým

    // Character Controller ile %100 uyumlu çalýþan Trigger fonksiyonu
    private void OnTriggerEnter(Collider other)
    {
        // Deðen objenin Tag'i "Player" mý?
        if (other.CompareTag("Player"))
        {
            // Oyuncunun üzerindeki PlayerMovement koduna eriþ
            PlayerMovement movement = other.GetComponent<PlayerMovement>();

            if (movement != null)
            {
                // Karakteri yukarý fýrlat
                movement.DisaridanZiplat(bounceForce);
                Debug.Log("Mantar tetiklendi ve oyuncuyu fýrlattý!");
            }
        }
    }
}