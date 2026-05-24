using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 currentCheckpoint;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Baþlangýç noktasýný ilk checkpoint olarak kaydet
        currentCheckpoint = transform.position;
    }

    public void SetNewCheckpoint(Vector3 pos)
    {
        currentCheckpoint = pos;
    }

    public void Respawn()
    {
        // Character Controller'ý kýsa süreliðine kapatmak gerekir yoksa ýþýnlanmaya izin vermez
        if (controller != null) controller.enabled = false;

        transform.position = currentCheckpoint;

        if (controller != null) controller.enabled = true;

        Debug.Log("Oyuncu en son checkpoint'e döndü.");
    }
}