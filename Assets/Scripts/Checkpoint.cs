using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncunun içindeki "Respawn" koduna bu konumu kaydet
            PlayerRespawn respawnSystem = other.GetComponent<PlayerRespawn>();
            if (respawnSystem != null)
            {
                respawnSystem.SetNewCheckpoint(transform.position);
                Debug.Log("Checkpoint Kaydedildi!");
            }
        }
    }
}