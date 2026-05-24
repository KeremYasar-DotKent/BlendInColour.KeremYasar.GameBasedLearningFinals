using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [Header("Dönüþ Ayarlarý")]
    public float rotationSpeed = 50f; // Dönüþ hýzý

    void Update()
    {
        // Objeyi kendi Y ekseni etrafýnda döndürür. 
        // Ýçindeki dikdörtgen merkeze baðlý olduðu için silindir etrafýnda döner.
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}