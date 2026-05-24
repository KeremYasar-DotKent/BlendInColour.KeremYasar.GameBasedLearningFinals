using UnityEngine;

public class ColorElevator : MonoBehaviour
{
    [Header("Renk ve Hareket Ayarlarý")]
    public RedTone requiredTone;      // Çalýþmasý için gereken renk
    public float targetHeight = 5f;   // Ne kadar yükselecek?
    public float speed = 3f;          // Hareket hýzý

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool playerOnBoard = false; // Oyuncu üstünde mi?

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + Vector3.up * targetHeight;
    }

    void Update()
    {
        // Hedef Belirleme: Oyuncu üstündeyse endPosition, deðilse startPosition
        Vector3 currentTarget = playerOnBoard ? endPosition : startPosition;

        // Pürüzsüz hareket
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    // Oyuncu asansörün alanýna girdiðinde
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColor pColor = other.GetComponent<PlayerColor>();

            // Eðer oyuncunun rengi doðruysa yukarý çýkýþ izni ver
            if (pColor != null && pColor.myCurrentTone == requiredTone)
            {
                playerOnBoard = true;
            }
            else
            {
                // Renk yanlýþsa veya deðiþirse çýkýþý durdur/aþaðý in
                playerOnBoard = false;
            }
        }
    }

    // Oyuncu asansörden indiðinde veya düþtüðünde
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnBoard = false;
        }
    }
}