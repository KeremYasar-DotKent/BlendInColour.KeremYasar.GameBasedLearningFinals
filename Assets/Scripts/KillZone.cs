using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawnSystem = other.GetComponent<PlayerRespawn>();
            if (respawnSystem != null)
            {
                respawnSystem.Respawn();
            }
        }
    }
}