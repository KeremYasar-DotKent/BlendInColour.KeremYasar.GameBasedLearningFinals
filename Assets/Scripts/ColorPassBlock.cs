using UnityEngine;

public class ColorPassBlock : MonoBehaviour
{
    public RedTone requiredTone; // Bu kapýnýn rengi
    private Collider myCollider;

    void Awake()
    {
        myCollider = GetComponent<Collider>();
    }

    // Bu fonksiyonu oyuncu renk aldýðýnda dýþarýdan çaðýracaðýz
    public void CheckAndOpen(RedTone playerTone)
    {
        if (playerTone == requiredTone)
        {
            // Renk tutuyorsa: Kapýyý sonsuza kadar hayalet yap ve bir daha kapatma
            myCollider.isTrigger = true;
            Debug.Log(gameObject.name + " rengi onayladý ve açýldý!");
        }
        else
        {
            // Renk tutmuyorsa veya baþka renk aldýysan: Kapýyý katý yap
            myCollider.isTrigger = false;
        }
    }
}