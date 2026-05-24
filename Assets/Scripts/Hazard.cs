using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Oyuncu bu objeye deðdiðinde
    void OnTriggerEnter(Collider other)
    {
        // Deðen objenin Tag'i "Player" mý diye kontrol et
        if (other.CompareTag("Player"))
        {
            // Oyuncunun üzerindeki Respawn sistemine eriþ
            PlayerRespawn respawnSystem = other.GetComponent<PlayerRespawn>();

            if (respawnSystem != null)
            {
                // Onu en son checkpoint'e geri gönder
                respawnSystem.Respawn();
                Debug.Log("Oyuncu bir engele çarptý ve öldü!");
            }
        }
    }

    // Eðer objen Trigger deðilse (katýysa) bu versiyonu kullanabilirsin
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRespawn respawnSystem = collision.gameObject.GetComponent<PlayerRespawn>();
            if (respawnSystem != null)
            {
                respawnSystem.Respawn();
            }
        }
    }
}