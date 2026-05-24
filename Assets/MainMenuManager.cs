using UnityEngine;
using UnityEngine.SceneManagement; // Sahneleri yüklemek için bu kütüphane þart!

public class MainMenuManager : MonoBehaviour
{
    // Oyunu baþlatacak fonksiyon
    public void PlayGame()
    {
        // Ýlk oyun sahnemizin adý neyse onu buraya yazýyoruz.
        // Senin ilk sahnen büyük ihtimalle "Level1(Red)" idi. Birebir ayný adý yaz.
        SceneManager.LoadScene("Level1(Red)");
    }

    // Oyundan çýkýþ yapacak fonksiyon
    public void QuitGame()
    {
        Debug.Log("Oyundan çýkýldý! (Bu yazý sadece editörde görünür, build alýnca oyun kapanýr)");
        Application.Quit(); // Gerçek oyunda pencereyi kapatýr
    }
}